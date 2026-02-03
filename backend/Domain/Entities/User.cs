using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class User
    {
        public int User_id { get; set; }
        public int Emp_id { get; set; }
        public int Rol_id { get; set; }
        public string PasswordHash { get; set; }
    }
}
