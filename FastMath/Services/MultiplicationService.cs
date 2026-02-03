using FastMath.Core.Interfaces;
using FastMath.Core.Models.OperationsWorld.Operand.OperandMetaParameter;
using FastMath.Core.Models.OperationsWorld.Operations;
using FastMath.Core.Models.OperationsWorld.Operations.Types;

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
