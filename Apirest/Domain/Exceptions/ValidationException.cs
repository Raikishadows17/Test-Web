using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Exceptions
{
    public class ValidationException : DomainException
    {
        public List<string> Errors { get; private set; }
        public ValidationException(List<string> errors) 
            : base("Errores de validacion")
        {
            Errors = errors;
        }
    }
}
