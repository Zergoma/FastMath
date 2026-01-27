using FastMath.Core.Abstraction;
using FastMath.Core.Models;
using FastMath.Core.Models.Operations;

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

            /// <summary>
            /// Calculates the maximum result of an operation between two operand options, based on the current
            /// operation type.
            /// </summary>
            /// <remarks>Supported operations include addition, multiplication, subtraction (returns
            /// the greater of the two maximums), and division. The method relies on the runtime type of the operation
            /// to determine the calculation performed.</remarks>
            /// <param name="left">The left operand to use in the calculation. Must provide a valid maximum value via its GetMax property.</param>
            /// <param name="right">The right operand to use in the calculation. Must provide a valid maximum value via its GetMax property.</param>
            /// <returns>A decimal value representing the result of the operation applied to the maximum values of the operands.</returns>
            /// <exception cref="NotImplementedException">Thrown when the current operation type is not supported by this method.</exception>
            private Decimal ComputeMax(OperandOptionBase left, OperandOptionBase right)
            {
                return operationBase switch
                {
                    AdditionnalOp => left.GetMax + right.GetMax,
                    MultiplyOp => left.GetMax * right.GetMax,
                    SubtractionOp => Math.Max(left.GetMax, right.GetMax),
                    DivideOp => Math.Max(left.GetMax, right.GetMax),
                    _ => throw new NotImplementedException(),
                };
            }

            /// <summary>
            /// Gets the string representation of the current mathematical operation.
            /// </summary>
            /// <remarks>This method checks the type of the current operation and returns the
            /// corresponding symbol. Ensure that the operationBase is set to a valid operation type before calling this
            /// method.</remarks>
            /// <returns>A string that represents the operation, such as "+", "-", "x", or "/".</returns>
            /// <exception cref="NotImplementedException">Thrown if the operation type is not recognized.</exception>
            public string GetOperationStr()
            {
                return operationBase switch
                {
                    AdditionnalOp => "+",
                    DivideOp => "/",
                    MultiplyOp => "x",
                    SubtractionOp => "-",
                    _ => throw new NotImplementedException()
                };
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

            /// <summary>
            /// Ensures that the Left value of the associated operation is greater than or equal to the Right value by
            /// swapping them if necessary.
            /// </summary>
            /// <remarks>Call this method to guarantee that the Left operand is not less than the
            /// Right operand. This method modifies the state of the underlying operation directly.</remarks>
            public void BiggestOnLeft()
            {
                if(operationBase.Left < operationBase.Right)
                {
                    (operationBase.Left, operationBase.Right) =
                        (operationBase.Right, operationBase.Left);
                }
            }

            /// <summary>
            /// Filters and returns the applicable operation masks for the current operation type.
            /// </summary>
            /// <remarks>This method determines which operation masks are relevant based on the
            /// runtime type of the current operation. It supports operation types such as division, subtraction, and
            /// multiplication. If the operation type does not match any of the supported types, the returned array will
            /// be empty.</remarks>
            /// <returns>An array of <see cref="EOperationMask"/> values representing the operation masks that apply to the
            /// current operation. The array is empty if no masks are applicable.</returns>
            public EOperationMask[] FiltreMask()
            {
                List<EOperationMask> prohibitedPosition = operationBase switch
                {
                    SubtractionOp => [EOperationMask.left],
                    MultiplyOp => [EOperationMask.left],
                    DivideOp => [EOperationMask.left, EOperationMask.right],
                    _ => []
                };

                return prohibitedPosition.ToArray();
            }
        }
    }
}
