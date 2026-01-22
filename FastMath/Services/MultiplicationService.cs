using FastMath.Core.Abstraction;
using FastMath.Core.Models;
using FastMath.Core.Models.Operations;

namespace FastMath.Services
{
    public class MultiplicationService : IGetMultiplication
    {
        public MultiplyOp GetMultiplication(ComputeOperandOption optionOperand1, ComputeOperandOption optionOperand2)
        {
            return new()
            {
                Left = optionOperand1.GetValue(),
                Right = optionOperand2.GetValue()
            };
        }
    }
}
