using FastMath.Core.Models.OperationsWorld.Operand.OperandRange.Types;

namespace FastMath.Core.Models.OperationsWorld.OperationParameters.Types
{
    public class SubstractSimpleParameters : OperationSettingParametersBase
    {
        public static SubstractSimpleParameters Create()
        {
            SubstractSimpleParameters parameter = new()
            {
                NbSuggested = 4,
                BiggestOnLeft = true,
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
