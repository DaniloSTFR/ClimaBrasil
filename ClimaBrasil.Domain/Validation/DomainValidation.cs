using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClimaBrasil.Domain.Validation
{
    public class DomainValidation : Exception
    {
        public DomainValidation(string error) : base(error)
        { }

        public static void When(bool hasError, string error)
        {
            if (hasError)
                throw new DomainValidation(error);
        }
    }
}