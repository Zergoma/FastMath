namespace FastMath.Core.Models.OperationsWorld.Operand.OperandMetaParameter.Types
{
    public class RandomOperandOption : OperandOptionBase
    {
        public RandomOperandOption(decimal Value, bool zeroAuthorized = true)
            : base(Value, zeroAuthorized)
        {
            DecimalNumber = BitConverter.GetBytes(decimal.GetBits(Value)[3])[2];
        }

        private static readonly Random rdm = Random.Shared;
        public override bool CanBeUsedForDivide()
        {
            return !ZeroAuthorized;
        }

        public override decimal GetValue() => GetRandomized();

        private int DecimalNumber { get; init; }
        private Decimal GetRandomized()
        {
            decimal val = Decimal.Zero;

            while (val == Decimal.Zero)
            {
                val = (decimal)rdm.NextDouble() * GetMax;
                val = Math.Round(val, DecimalNumber);

                if (ZeroAuthorized)
                {
                    break;
                }
            }
            return val;
        }
    }
}
