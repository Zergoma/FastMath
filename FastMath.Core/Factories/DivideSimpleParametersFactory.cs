using FastMath.Core.Interfaces;
using FastMath.Core.Models.OperationsWorld.OperationParameters;
using FastMath.Core.Models.OperationsWorld.OperationParameters.Types;

namespace FastMath.Core.Factories
{
    public partial class DivideSimpleParametersFactory : IOperationSettingFactory
    {
        public OperationSettingParametersBase Create()
        {
            return DivideSimpleParameters.Create();
        }
    }
}
