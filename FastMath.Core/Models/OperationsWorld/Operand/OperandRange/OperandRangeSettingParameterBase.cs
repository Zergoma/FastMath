using FastMath.Core.Models.OperationsWorld.Operand.OperandRange.Types;
using System.Xml.Serialization;

namespace FastMath.Core.Models.OperationsWorld.Operand.OperandRange
{
    [XmlInclude(typeof(OperandFixValueParameter))]
    [XmlInclude(typeof(OperandRangeValueParameter))]
    public abstract class OperandRangeSettingParameterBase
    {
        public bool CanBeZero { get; set; } = true;
    }
}
