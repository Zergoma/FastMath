using FastMath.Core.Models.OperationsWorld.Operand.OperandRange.Types;

namespace FastMath.Core.Models.OperationsWorld.OperationParameters.Types
{
    public class DivideSimpleParameters : OperationSettingParametersBase
    {
        public static DivideSimpleParameters Create()
        {
            DivideSimpleParameters parameter = new()
            {
                NbSuggested = 4,
                BiggestOnLeft = true,
                RangeParameterLeft = new OperandRangeValueParameter()
                {
                    CanBeZero = false,
                    MinMax = [0m, 10m],
                },

                RangeParameterRight = new OperandRangeValueParameter()
                {
                    CanBeZero = false,
                    MinMax = [1m, 10m],
                }
            };

            return parameter;
        }
    }
}
