using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Application.DTOs
{
    public class UserDTO
    {
        public int User_id { get; set; }
        public string Username { get; set; } = string.Empty;
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWriting)]
        public string Password { get; set; } = string.Empty;
        public int Emp_id { get; set; }
        public ICollection<UserRolDTO> Rol {get; set; } = new List<UserRolDTO>();
        public string EmployeeName { get; set; } = string.Empty;
    }
}
