using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using Model.Commands.Interfaces;

namespace Model.Commands
{
    [CommandOperator('+')]
    public class SumCommand : ICalculateCommand
    {
        private BigInteger _result;
        private readonly List<BigInteger> _operand;

        public SumCommand(List<BigInteger> operand)
        {
            _operand = operand;
        }

        public void Execute()
        {
            _result = _operand.Aggregate((a, c) => a + c);
        }

        public string GetResult()
        {
            return _result.ToString();
        }
    }
}