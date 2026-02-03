using FastMath.Core.Helpers;
using FastMath.Core.Interfaces;
using FastMath.Helper;
using FastMath.Services;

namespace FastMath.MVVM.ViewModels
{
    public partial class SimpleSubstractionViewModel : SimpleOperationBaseViewModel
    {
        public SimpleSubstractionViewModel([FromKeyedServices(OperationServiceKeys.Subtraction)] IGetOperation service,
                                           GenerateSimpleOperationHelper generateSimpleOperation,
                                           [FromKeyedServices(SettingHelperKeys.Subtraction)] IGetUserSetting settingHelper)
            : base(service,
                   generateSimpleOperation,
                   settingHelper)
        {
        }
    }
}
