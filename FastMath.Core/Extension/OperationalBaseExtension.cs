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

            public Decimal GetOffuscatedValue(EOperationMask mask)
            {
                return mask switch
                {
                    EOperationMask.left => operationBase.Left,
                    EOperationMask.right => operationBase.Right,
                    EOperationMask.result => operationBase.Compute(),
                    _ => throw new ArgumentOutOfRangeException(nameof(mask), "Must Left, Right or Result"),
                };
            }

            public Decimal GetOffuscatedValueMax(EOperationMask mask, OperandOptionBase left, OperandOptionBase right)
            {
                return mask switch
                {
                    EOperationMask.left => left.GetMax,
                    EOperationMask.right => right.GetMax,
                    EOperationMask.result => operationBase.ComputeMax(left, right),
                    _ => throw new ArgumentOutOfRangeException(nameof(mask), "Must Left, Right or Result"),
                };
            }

            private Decimal ComputeMax(OperandOptionBase left, OperandOptionBase right)
            {
                if (operationBase is AdditionnalOp) return left.GetMax + right.GetMax;
                if (operationBase is MultiplyOp) return left.GetMax * right.GetMax;
                if (operationBase is SoustractionOp) return left.GetMax - right.GetMax;
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
            public string ToString(EOperationMask mask)
            {
                return mask switch
                {
                    EOperationMask.left => $"? {operationBase.GetOperationStr()} {operationBase.Right} = {operationBase.Compute()}",
                    EOperationMask.right => $"{operationBase.Left} {operationBase.GetOperationStr()} ? = {operationBase.Compute()}",
                    EOperationMask.result => $"{operationBase.Left} {operationBase.GetOperationStr()} {operationBase.Right} = ?",
                    EOperationMask.none => $"{operationBase.Left} {operationBase.GetOperationStr()} {operationBase.Right} = {operationBase.Compute()}",
                    _ => throw new NotImplementedException(),
                };
            }
        }
    }
}
