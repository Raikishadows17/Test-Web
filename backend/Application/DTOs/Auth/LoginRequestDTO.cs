using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DTOs.Auth
{
    public class LoginRequestDTO
    {
        public string UserName { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }
}
