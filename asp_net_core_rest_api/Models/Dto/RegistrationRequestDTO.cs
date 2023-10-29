using System;
namespace asp_net_core_rest_api.Models.Dto
{
	public class RegistrationRequestDTO
	{
        public string UserName { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
    }
}

