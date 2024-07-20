using System.Linq;
using System.Numerics;
using System.Text.RegularExpressions;

namespace Model.Validations
{
    public abstract class CalculatorInputValidator
    {
        public static ValidationResult Validate(string input)
        {
            var pattern = @"^\s*(-?\d+)\s*([+\-*/])\s*(-?\d+)\s*$";
            var regex = new Regex(pattern);
            var match = regex.Match(input);

            if (!match.Success)
            {
                return null;
            }

            if (!BigInteger.TryParse(match.Groups[1].Value, out var a))
            {
                return null;
            }

            if (!BigInteger.TryParse(match.Groups[3].Value, out var b))
            {
                return null;
            }


            return new ValidationResult
            {
                Operator = match.Groups[2].Value.First(),
                Operands = new() { a, b, }
            };
        }
    }
}