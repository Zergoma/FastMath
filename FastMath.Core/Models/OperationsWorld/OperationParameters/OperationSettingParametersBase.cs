using FastMath.Core.Enums;
using FastMath.Core.Models.OperationsWorld.Operand.OperandRange;
using FastMath.Core.Models.OperationsWorld.OperationParameters.Types;
using System.Xml.Serialization;

namespace FastMath.Core.Models.OperationsWorld.OperationParameters
{
    [XmlInclude(typeof(AdditionSimpleParameters))]
    [XmlInclude(typeof(DivideSimpleParameters))]
    [XmlInclude(typeof(MultiplySimpleParameters))]
    [XmlInclude(typeof(SubstractSimpleParameters))]
    public abstract class OperationSettingParametersBase
    {
        private const int NbSuggestedAnswer = 4;
        public int NbSuggested { get; set; } = NbSuggestedAnswer;
        public bool BiggestOnLeft { get; set; } = true;
        public List<EOperationMask> BlackListMask { get; set; } = new();
        public OperandRangeSettingParameterBase? RangeParameterLeft { get; set; } = null;
        public OperandRangeSettingParameterBase? RangeParameterRight { get; set; } = null;
    }
}
