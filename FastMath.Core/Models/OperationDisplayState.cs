using FastMath.Core.Abstraction;


namespace FastMath.Core.Models
{
    public record OperationDisplayState(
        OperationalBase Operation,
        OperationMask Mask,
        OperationalVisibility Visibility
    );
}
