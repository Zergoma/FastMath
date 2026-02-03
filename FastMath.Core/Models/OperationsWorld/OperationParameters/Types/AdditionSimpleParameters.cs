using FastMath.Core.Models.OperationsWorld.Operand.OperandRange.Types;

namespace FastMath.Core.Models.OperationsWorld.OperationParameters.Types
{
    public class AdditionSimpleParameters : OperationSettingParametersBase
    {
        public static AdditionSimpleParameters Create()
        {
            AdditionSimpleParameters parameter = new()
            {
                NbSuggested = 4,
                BiggestOnLeft = false,
                RangeParameterLeft = new OperandRangeValueParameter()
                {
                    CanBeZero = true,
                    MinMax = [0m, 10m],
                },

                RangeParameterRight = new OperandRangeValueParameter()
                {
                    CanBeZero = true,
                    MinMax = [0m, 10m],
                }
            };

            return parameter;
        }
    }
}
