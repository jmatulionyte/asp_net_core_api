using System;
using asp_net_core_rest_api.Models;
using System.Linq.Expressions;
using asp_net_core_rest_api.Models.Dto;

namespace asp_net_core_rest_api.Repository.IRepository
{
	//registering user to db
	public interface IUserRepository
	{ //checkif users id unique or not
		bool isUserUnique(string username);
		Task<LoginResponseDTO> Login(LoginRequestDTO loginRequestDTO);
		Task<UserDTO> Register(RegistrationRequestDTO registerationRequestDTO);
    }
}

