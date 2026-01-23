using System;
using System.Collections.Generic;
using System.Text;

namespace FastMath.Core.Abstraction
{
    public abstract class OperandOptionBase
    {
        public bool ZeroAuthorized { get; init; }

        public abstract Decimal GetValue();
        public abstract bool CanBeUsedForDivide();
        public Decimal GetMax { get; init; }

        protected OperandOptionBase(decimal Value, bool zeroAuthorized = true)
        {
            ArgumentOutOfRangeException.ThrowIfLessThan(Value, Decimal.Zero, nameof(Value));

            ZeroAuthorized = zeroAuthorized;
            if (ZeroAuthorized is false)
            {
                ArgumentOutOfRangeException.ThrowIfZero(Value, nameof(Value));
            }

            GetMax = Value;
        }
    }
}
