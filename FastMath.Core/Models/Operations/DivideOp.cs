using FastMath.Core.Abstraction;

namespace FastMath.Core.Models.Operations
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
