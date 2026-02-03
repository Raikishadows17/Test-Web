using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class Customer
    {
        public int customerId { get; set; }
        public string Name { get; set; }
        public string Razon_Social { get; set; }
        public string RFC { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Alternative_Phone { get; set; }
        public string Address { get; set; }
        public string Alternative_Address { get; set; }
    }
}
