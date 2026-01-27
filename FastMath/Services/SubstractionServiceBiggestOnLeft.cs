using FastMath.Core.Abstraction;
using FastMath.Core.Extension;
using FastMath.Core.Models.Operations;

namespace FastMath.Services
{
    public class SubstractionServiceBiggestOnLeft : IGetOperation
    {
        public OperationalBase CreateOperation(OperandOptionBase optionOperand1, OperandOptionBase optionOperand2)
        {
            SubtractionOp subop = new()
            {
                Left = optionOperand1.GetValue(),
                Right = optionOperand2.GetValue(),
            };


            subop.BiggestOnLeft();

            return subop;
        }
    }
}
