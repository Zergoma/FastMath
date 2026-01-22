using FastMath.Core.Abstraction;


namespace FastMath.Core.Models
{
    public record OperationDisplayState(
        OperationalBase Operation,
        EOperationMask Mask,
        OperationalVisibility Visibility
    );
}
