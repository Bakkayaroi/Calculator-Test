using System.Collections.Generic;
using System.Numerics;

namespace Model.Validations
{
    public class ValidationResult
    {
        public char Operator { get; set; }
        public List<BigInteger> Operands { get; set; }
    }
}