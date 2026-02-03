using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    internal class Employee
    {
        public int Emp_id { get; set; }
        public long EmployeeNumber { get; set; }
        public string Full_Name { get; set; }
        public DateOnly Join_Date { get; set; }
        public int Phone_Number { get; set; }
        public int Alternate_Number { get; set; }
        public string Guild { get; set; }
    }
}
