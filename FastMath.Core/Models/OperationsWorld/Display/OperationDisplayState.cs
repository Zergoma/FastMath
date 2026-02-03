using FastMath.Core.Enums;
using FastMath.Core.Models.OperationsWorld.Operations;

namespace FastMath.Core.Models.OperationsWorld.Display
{
    public record OperationDisplayState(
        OperationalBase Operation,
        EOperationMask Mask,
        OperationalVisibility Visibility
    );
}
