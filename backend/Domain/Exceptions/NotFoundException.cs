using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Exceptions
{
    public class NotFoundException : DomainException
    {
        public NotFoundException(string message) : base(message)
        {
        }
    }
}
