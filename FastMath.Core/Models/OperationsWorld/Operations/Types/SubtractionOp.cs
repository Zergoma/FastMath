namespace FastMath.Core.Models.OperationsWorld.Operations.Types
{
    public class SubtractionOp : OperationalBase
    {
        public override Decimal Compute()
        {
            return Left - Right;
        }
    }
}
