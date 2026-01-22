using System.Diagnostics;

namespace FastMath.Core.Models
{
    /// <summary>
    /// Represents an option for computing an operand maxOrValue, supporting fixed or randomized modes with configurable
    /// decimal precision.
    /// </summary>
    /// <remarks>Use this class to specify how a numeric operand should be generated—either as a fixed value
    /// or as a randomized MAX up to a specified maximum. The mode and maxOrValue are determined by the provided
    /// parameters. This type is typically used in scenarios where operand values need to be generated dynamically
    /// according to specific rules.</remarks>
    public class ComputeOperandOption
    {
        private static readonly Random rdm = Random.Shared;
        private OperandDof Dof { get; init; }
        
        /// <summary>
        /// Gets the maximum value or the specified value, depending on the context.
        /// </summary>
        public Decimal MaxOrValue { get; init; }
        
        /// <summary>
        /// semantic Helper : random context when we need maximum
        /// </summary>
        private Decimal Max => MaxOrValue;

        /// <summary>
        /// semantic Helper : Fixed value context
        /// </summary>
        private Decimal Value => MaxOrValue;

        private int DecimalNumber { get; init; }
        public bool ZeroAuthorized { get; init; }

        public bool CanBeUsedForDivide()
        {
            if( (Dof == OperandDof.randomized && ZeroAuthorized) ||
                (Dof == OperandDof.fix && Value == Decimal.Zero))
            {
                return false;
            }
            return true;
        }

        public ComputeOperandOption(OperandDof randOrFixed, decimal maxOrValue, int decimalNumber = 0, bool zeroAuthorized = true)
        {
            ArgumentOutOfRangeException.ThrowIfLessThan(maxOrValue, Decimal.Zero, nameof(maxOrValue));

            ZeroAuthorized = zeroAuthorized;
            if(ZeroAuthorized is false)
            {
                ArgumentOutOfRangeException.ThrowIfZero(maxOrValue, nameof(zeroAuthorized));
            }

            Dof = randOrFixed;
            MaxOrValue = maxOrValue;
            DecimalNumber = decimalNumber;
        }

        public Decimal GetValue()
        {
            return Dof switch
            {
                OperandDof.fix => GetFix(),
                OperandDof.randomized => GetRandomized(),
                _ => throw new UnreachableException(),
            };
        }

        private Decimal GetFix()
        {
            return Math.Round(Value, DecimalNumber);
        }

        private Decimal GetRandomized()
        {
            decimal val = Decimal.Zero;

            while (val == Decimal.Zero)
            {
                val = (decimal)rdm.NextDouble() * Max;
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
