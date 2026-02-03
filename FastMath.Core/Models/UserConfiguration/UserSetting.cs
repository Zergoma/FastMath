using FastMath.Core.Models.OperationsWorld.OperationParameters;

namespace FastMath.Core.Models.UserConfiguration
{
    public class UserSetting
    {
        public string Name { get; set; } = string.Empty;
        public List<OperationSettingParametersBase> ParametersList { get; set; } = new();
    }

}
