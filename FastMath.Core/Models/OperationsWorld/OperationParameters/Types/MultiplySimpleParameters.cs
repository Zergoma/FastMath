using FastMath.Core.Models.OperationsWorld.Operand.OperandRange.Types;

namespace FastMath.Core.Models.OperationsWorld.OperationParameters.Types
{
    public class MultiplySimpleParameters : OperationSettingParametersBase
    {
        public static MultiplySimpleParameters Create()
        {
            MultiplySimpleParameters parameter = new()
            {
                NbSuggested = 4,
                BiggestOnLeft = false,
                RangeParameterLeft = new OperandRangeValueParameter()
                {
                    CanBeZero = false,
                    MinMax = [1m, 10m],
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
