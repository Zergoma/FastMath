using FastMath.Core.Models.OperationsWorld.OperationParameters;

namespace FastMath.Core.Interfaces
{
    public interface IGetCurrentOperationSetting
    {
        OperationSettingParametersBase OperationParameter { get; init; }
    }
}
