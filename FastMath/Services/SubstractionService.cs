using FastMath.Core.Abstraction;
using FastMath.Core.Extension;
using FastMath.Core.Models;
using FastMath.Core.Models.Operations;

namespace FastMath.Services
{
    public class SubstractionService : IGetOperation
    {
        public bool BiggestOnLeft { get; set; }
        public OperationalBase CreateOperation(OperandOptionBase optionOperand1, OperandOptionBase optionOperand2)
        {
            SubtractionOp subop = new ()
            {
                Left = optionOperand1.GetValue(),
                Right = optionOperand2.GetValue(),
            };

            if(BiggestOnLeft)
            {
                subop.BiggestOnLeft();
            }

            return subop;
        }
    }
}
