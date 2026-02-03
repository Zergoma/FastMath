using FastMath.Core.Interfaces;
using FastMath.Core.Models.OperationsWorld.Operand.OperandMetaParameter;
using FastMath.Core.Models.OperationsWorld.Operations;
using FastMath.Core.Models.OperationsWorld.Operations.Types;


namespace FastMath.Services
{
    public class DivideService : IGetOperation
    {
        public OperationalBase CreateOperation(OperandOptionBase optionOperand1, OperandOptionBase optionOperand2)
        {
            if (optionOperand2.CanBeUsedForDivide() is false)
            {
                throw new ArgumentException("The option for operand2 MUST be explicitely ZeroAuthorized to false", nameof(optionOperand2));
            }

            var num1 = optionOperand1.GetValue();
            var num2 = optionOperand2.GetValue();
            var numresu = num1 * num2;

            DivideOp resu =  new ()
            {
                Left = numresu,
                Right = num2
            };

            return resu;
        }
    }
}
