namespace FastMath.Core.Models.OperationsWorld.Operations.Types
{
    public class MultiplyOp : OperationalBase
    {
        public override Decimal Compute()
        {
            return Left * Right;
        }
    }
}
