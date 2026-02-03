using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DTOs
{
    public class UserDTO
    {
        public int User_id { get; set; }
        public int Emp_id { get; set; }
        public int Rol_id { get; set; }
        public string Email { get; set; } = string.Empty;
        public string EmployeeName { get; set; } = string.Empty;
        public string TenantId { get; set; } = string.Empty;
    }
}
