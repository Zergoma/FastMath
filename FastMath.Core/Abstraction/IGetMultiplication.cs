using FastMath.Core.Models;
using FastMath.Core.Models.Operations;

namespace FastMath.Core.Abstraction
{
    public interface IGetMultiplication
    {
        MultiplyOp GetMultiplication(ComputeOperandOption optionOperand1, ComputeOperandOption optionOperand2);
    }
}