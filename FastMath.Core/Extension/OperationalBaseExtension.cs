using FastMath.Core.Abstraction;
using FastMath.Core.Models;
using FastMath.Core.Models.Operations;
using System;
using System.Collections.Generic;
using System.Runtime.Intrinsics.Arm;
using System.Text;

namespace FastMath.Core.Extension
{
    static public class OperationalBaseExtension
    {
        static private readonly Random rdm = Random.Shared;

        extension(OperationalBase operationBase)
        {
            public void RandomInit(Decimal max, uint decimalPlaces)
            {
                decimal left = (decimal)rdm.NextDouble() * max;
                decimal right = (decimal)rdm.NextDouble() * max;

                // decimal number
                left = Math.Round(left, (int)decimalPlaces);
                right = Math.Round(right, (int)decimalPlaces);

                operationBase.Left = left;
                operationBase.Right = right;
            }

            public Decimal GetOffuscatedValue(OperationMask mask)
            {
                return mask.Masked switch
                {
                    OperationMasked.left => operationBase.Left,
                    OperationMasked.right => operationBase.Right,
                    OperationMasked.result => operationBase.Compute(),
                    _ => throw new ArgumentOutOfRangeException(nameof(mask.Masked), "Must Left, Right or Result"),
                };
            }

            public Decimal GetOffuscatedValueMax(OperationMask mask, ComputeOperandOption left, ComputeOperandOption right)
            {
                return mask.Masked switch
                {
                    OperationMasked.left => left.MaxOrValue,
                    OperationMasked.right => right.MaxOrValue,
                    OperationMasked.result => operationBase.ComputeMax(left, right),
                    _ => throw new ArgumentOutOfRangeException(nameof(mask.Masked), "Must Left, Right or Result"),
                };
            }

            private Decimal ComputeMax(ComputeOperandOption left, ComputeOperandOption right)
            {
                if (operationBase is AdditionnalOp) return left.MaxOrValue + right.MaxOrValue;
                if (operationBase is MultiplyOp) return left.MaxOrValue * right.MaxOrValue;
                if (operationBase is SoustractionOp) return left.MaxOrValue - right.MaxOrValue;
                if (operationBase is DivideOp)
                {
                    if (right.GetValue() == decimal.Zero)
                    {
                        throw new DivideByZeroException();
                    }
                    return left.GetValue() / right.GetValue();
                };

                throw new NotImplementedException();
            }

            public string GetOperationStr()
            {
                if (operationBase is AdditionnalOp) return "+";
                if (operationBase is DivideOp) return "/";
                if (operationBase is MultiplyOp) return "x";
                if (operationBase is SoustractionOp) return "-";
                
                throw new NotImplementedException();
            }
            public string ToString(OperationMask mask)
            {
                return mask.Masked switch
                {
                    OperationMasked.left => $"? {operationBase.GetOperationStr()} {operationBase.Right} = {operationBase.Compute()}",
                    OperationMasked.right => $"{operationBase.Left} {operationBase.GetOperationStr()} ? = {operationBase.Compute()}",
                    OperationMasked.result => $"{operationBase.Left} {operationBase.GetOperationStr()} {operationBase.Right} = ?",
                    OperationMasked.none => $"{operationBase.Left} {operationBase.GetOperationStr()} {operationBase.Right} = {operationBase.Compute()}",
                    _ => throw new NotImplementedException(),
                };
            }
        }
    }
}
