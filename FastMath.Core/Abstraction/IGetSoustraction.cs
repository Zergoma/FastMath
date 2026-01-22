using FastMath.Core.Models;
using FastMath.Core.Models.Operations;

namespace FastMath.Core.Abstraction
{
    public interface IGetSoustraction
    {
        SoustractionOp GetSoustraction(ComputeOperandOption optionOperand1, ComputeOperandOption optionOperand2);
    }
}