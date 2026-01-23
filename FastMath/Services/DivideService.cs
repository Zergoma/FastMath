using FastMath.Core.Abstraction;
using FastMath.Core.Models;
using FastMath.Core.Models.Operations;


namespace FastMath.Services
{
    public class DivideService : IGetOperation
    {
        public OperationalBase CreateOperation(OperandOptionBase optionOperand1, OperandOptionBase optionOperand2)
        {
            if (optionOperand2.CanBeUsedForDivide() is false)
            {
                throw new ArgumentException("The option for operand2 MUST be explicitely ZeroAuthorized to false", nameof(optionOperand2));
            }

            return new DivideOp()
            {
                Left = optionOperand1.GetValue(),
                Right = optionOperand2.GetValue()
            };
        }
    }
}
