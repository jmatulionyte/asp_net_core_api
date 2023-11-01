using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using asp_net_core_rest_api.Data;
using asp_net_core_rest_api.Models;
using asp_net_core_rest_api.Models.Dto;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace asp_net_core_rest_api.Repository.IRepository
{
	public class UserRepository : IUserRepository
	{
        private readonly ApplicationDbContext _db;
        private string secretKey;
        //dependency injection
        public UserRepository(ApplicationDbContext db, IConfiguration configuration)
        {
            _db = db;
            secretKey = configuration.GetValue<string>("ApiSettings:Secret");
        }

        public bool isUserUnique(string username)
        {
            var user = _db.LocalUsers.FirstOrDefault(x => x.UserName == username);
            if (user == null) //no user with that username
            {
                return true;
            }
            return false;
        }

        public async Task<LoginResponseDTO> Login(LoginRequestDTO loginRequestDTO)
        {
            //check if there are user with sam eusername and pw
            var user = _db.LocalUsers.FirstOrDefault(x => x.UserName.ToLower() == loginRequestDTO.UserName.ToLower() &&
                x.Password == loginRequestDTO.Password);

            //user is not existant
            if (user == null)
            {
                return new LoginResponseDTO()
                {
                    Token = "",
                    User = null
                };
            }
            //if found generate jwt token, using secret and key  token will be encrypted
            //secret key is used to validate if token is valid or not
            //secret key is used to authenticate wether this token was generated in this api
            var tokenHandler = new JwtSecurityTokenHandler();
            //convert secretKey string to byte array
            var key = Encoding.ASCII.GetBytes(secretKey);
            //token descriptor, tell what are the claims in the token
            //claim identify users name, role, etc, custom claims, default cliam for user Id, role, etc,
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Id.ToString()),
                    new Claim(ClaimTypes.Role, user.Role)
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                //generates signning credential for token descriptor - how to encrypt
                SigningCredentials = new(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            //this token has type SecurityClass, so it cannot be passed as value?
            var token = tokenHandler.CreateToken(tokenDescriptor);
            LoginResponseDTO loginResponseDTO = new LoginResponseDTO()
            {
                //writetoken allogs to get token value 
                Token = tokenHandler.WriteToken(token),
                User = user
            };
            return loginResponseDTO;
        }

        public async Task<LocalUser> Register(RegistrationRequestDTO registerationRequestDTO)
        {
            LocalUser user = new LocalUser()
            {
                UserName = registerationRequestDTO.UserName,
                Password = registerationRequestDTO.Password,
                Name = registerationRequestDTO.Name,
                Role = registerationRequestDTO.Role
            };
            _db.LocalUsers.Add(user);
            await _db.SaveChangesAsync();
            user.Password = "";
            return user;
        }
    }
}

