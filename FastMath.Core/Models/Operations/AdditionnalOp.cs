using FastMath.Core.Abstraction;

namespace FastMath.Core.Models.Operations
{
    public partial class AdditionnalOp : OperationalBase
    {
        public override Decimal Compute()
        {
            return Left+Right;
        }
    }
}
