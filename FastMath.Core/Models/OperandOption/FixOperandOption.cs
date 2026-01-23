using FastMath.Core.Abstraction;

namespace FastMath.Core.Models.OperandOption
{
    public class FixOperandOption(decimal Value, bool zeroAuthorized = true) : OperandOptionBase(Value, zeroAuthorized)
    {
        public override decimal GetValue() => GetMax;

        public override bool CanBeUsedForDivide()
        {
            return GetValue() switch
            {
                Decimal.Zero => false,
                _ => true,
            };
        }
    }
}
