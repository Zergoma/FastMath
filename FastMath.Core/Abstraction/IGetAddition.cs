using FastMath.Core.Models;
using FastMath.Core.Models.Operations;

namespace FastMath.Core.Abstraction
{
    public interface IGetAddition
    {
        AdditionnalOp GetAddition(ComputeOperandOption optionOperand1, ComputeOperandOption optionOperand2);
    }
}