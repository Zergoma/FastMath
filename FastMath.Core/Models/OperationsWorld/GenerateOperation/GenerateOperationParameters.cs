using FastMath.Core.Interfaces;
using FastMath.Core.Models.OperationsWorld.Operand.OperandMetaParameter;

namespace FastMath.Core.Models.OperationsWorld.GenerateOperation
{
    public record GenerateOperationParameters(
        OperandOptionBase LeftOperandOption,
        OperandOptionBase RightOperandOption,
        IGetOperation OpService
    );
}
