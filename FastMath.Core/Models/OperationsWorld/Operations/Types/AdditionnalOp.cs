namespace FastMath.Core.Models.OperationsWorld.Operations.Types
{
    public partial class AdditionnalOp : OperationalBase
    {
        public override Decimal Compute()
        {
            return Left+Right;
        }
    }
}
