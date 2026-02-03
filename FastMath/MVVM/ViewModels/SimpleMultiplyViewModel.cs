using FastMath.Core.Helpers;
using FastMath.Core.Interfaces;
using FastMath.Helper;
using FastMath.Services;

namespace FastMath.MVVM.ViewModels
{
    public partial class SimpleMultiplyViewModel : SimpleOperationBaseViewModel
    {
        public SimpleMultiplyViewModel([FromKeyedServices(OperationServiceKeys.Multiplication)] IGetOperation service,
                                       GenerateSimpleOperationHelper generateSimpleOperation,
                                       [FromKeyedServices(SettingHelperKeys.Multiplication)] IGetUserSetting settingHelper)
            : base(service,
                   generateSimpleOperation,
                   settingHelper)
        {
        }
    }
}
