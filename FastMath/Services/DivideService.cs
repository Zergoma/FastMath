using FastMath.Core.Abstraction;
using FastMath.Core.Models;
using FastMath.Core.Models.Operations;


namespace FastMath.Services
{
    public class DivideService : IGetDivide
    {
        public DivideOp GetDivide(ComputeOperandOption optionOperand1, ComputeOperandOption optionOperand2)
        {
            if(optionOperand2.CanBeUsedForDivide() is false)
            {
                throw new ArgumentException("The option for operand2 MUST be explicitely ZeroAuthorized to false", nameof(optionOperand2));
            }

            return new()
            {
                Left = optionOperand1.GetValue(),
                Right = optionOperand2.GetValue()
            };
        }
    }
}
