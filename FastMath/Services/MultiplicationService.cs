using FastMath.Core.Abstraction;
using FastMath.Core.Models;
using FastMath.Core.Models.Operations;

namespace FastMath.Services
{
    public class MultiplicationService : IGetOperation
    {
        public OperationalBase CreateOperation(OperandOptionBase optionOperand1, OperandOptionBase optionOperand2)
        {
            return new MultiplyOp()
            {
                Left = optionOperand1.GetValue(),
                Right = optionOperand2.GetValue()
            };
        }
    }
}
