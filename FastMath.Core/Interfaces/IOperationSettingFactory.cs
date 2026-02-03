using FastMath.Core.Models.OperationsWorld.OperationParameters;

namespace FastMath.Core.Interfaces
{
    public interface IOperationSettingFactory
    {
        OperationSettingParametersBase Create();
    }
}
