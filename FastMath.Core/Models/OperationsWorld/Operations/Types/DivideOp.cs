namespace FastMath.Core.Models.OperationsWorld.Operations.Types
{
    public class DivideOp : OperationalBase
    {
        public override Decimal Compute()
        {
            if(Right == decimal.Zero)
            {
                throw new DivideByZeroException();
            }

            return Left / Right;
        }
    }
}
