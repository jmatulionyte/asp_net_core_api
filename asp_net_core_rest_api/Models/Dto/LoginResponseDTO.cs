﻿using System;
namespace asp_net_core_rest_api.Models.Dto
{
    public class LoginResponseDTO
    {
        public UserDTO User { get; set; }
        public string Token { get; set; } //authenticat identity of user
    }
}

