using FastMath.Core.Models.OperationsWorld.Operand.OperandMetaParameter;
using FastMath.Core.Models.OperationsWorld.Operand.OperandMetaParameter.Types;
using FastMath.Core.Models.OperationsWorld.Operand.OperandRange;
using FastMath.Core.Models.OperationsWorld.Operand.OperandRange.Types;

namespace FastMath.Core.Helpers
{
    static public class OperandCreationParameterHelper
    {
        static public OperandOptionBase Create(OperandRangeSettingParameterBase? config)
        {
            ArgumentNullException.ThrowIfNull(config, nameof(config));

            return config switch
            {
                OperandFixValueParameter fix => GenerateFix(fix),
                OperandRangeValueParameter rand => GenerateRandom(rand),
                _ => throw new NotSupportedException()
            };
        }

        static FixOperandOption GenerateFix(OperandFixValueParameter config) 
        {
            return new(config.FixedValue, config.CanBeZero);
        }

        static RandomOperandOption GenerateRandom(OperandRangeValueParameter config)
        {
            decimal max = config.MinMax.Max();
            return new(max, config.CanBeZero);
        }
    }
}
