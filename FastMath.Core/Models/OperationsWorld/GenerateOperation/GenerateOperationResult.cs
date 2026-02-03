using FastMath.Core.Enums;
using FastMath.Core.Models.OperationsWorld.Operations;

namespace FastMath.Core.Models.OperationsWorld.GenerateOperation
{
    public record GenerateOperationResult(
        OperationalBase Operation,
        EOperationMask Mask);
}
