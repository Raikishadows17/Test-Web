using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DTOs.Auth
{
    public class TokenResult
    {
        public string Token { get; set; }
        public DateTime Expiration { get; set; }
    }
}
