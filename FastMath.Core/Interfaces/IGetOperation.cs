using FastMath.Core.Models.OperationsWorld.Operand.OperandMetaParameter;
using FastMath.Core.Models.OperationsWorld.Operations;

namespace FastMath.Core.Interfaces
{
    public interface IGetOperation
    {
        public OperationalBase CreateOperation(OperandOptionBase optionOperand1, OperandOptionBase optionOperand2);
    }
}
