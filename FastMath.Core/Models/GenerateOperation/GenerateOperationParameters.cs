using FastMath.Core.Abstraction;

namespace FastMath.Core.Models.GenerateOperation
{
    public record GenerateOperationParameters(
        OperandOptionBase LeftOperandOption,
        OperandOptionBase RightOperandOption,
        IGetOperation OpService
    );
}
