using FastMath.Core.Models;
using FastMath.Core.Models.Operations;

namespace FastMath.Core.Abstraction
{
    public interface IGetDivide
    {
        DivideOp GetDivide(ComputeOperandOption optionOperand1, ComputeOperandOption optionOperand2);
    }
}