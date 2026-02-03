namespace FastMath.Core.Models.OperationsWorld.Operations
{
    /// <summary>
    /// Serves as the base class for operations that perform a computation and return a decimal result.
    /// </summary>
    /// <remarks>Inherit from this class to implement specific computation logic by overriding the Compute
    /// method. This class provides a common contract for computation-based operations.</remarks>
    public abstract class OperationalBase : ComputationData
    {
        public abstract Decimal Compute();
    }
}
