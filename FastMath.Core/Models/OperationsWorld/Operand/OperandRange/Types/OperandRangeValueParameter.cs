namespace FastMath.Core.Models.OperationsWorld.Operand.OperandRange.Types
{
    public class OperandRangeValueParameter : OperandRangeSettingParameterBase
    {
        public Decimal[] MinMax { get; set; } = new Decimal[2];
        public List<Decimal>? WhiteList{ get; set; } = null;
    }
}
