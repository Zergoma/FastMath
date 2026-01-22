using FastMath.Core.Abstraction;

namespace FastMath.Core.Models.Operations
{
    public class SoustractionOp : OperationalBase
    {
        public override Decimal Compute()
        {
            return Left - Right;
        }
    }
}
