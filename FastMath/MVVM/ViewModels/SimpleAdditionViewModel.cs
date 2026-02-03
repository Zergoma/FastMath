using FastMath.Core.Helpers;
using FastMath.Core.Interfaces;
using FastMath.Helper;
using FastMath.Services;

namespace FastMath.MVVM.ViewModels
{
    public partial class SimpleAdditionViewModel : SimpleOperationBaseViewModel
    {
        public SimpleAdditionViewModel([FromKeyedServices(OperationServiceKeys.Addition)] IGetOperation service,
                                       GenerateSimpleOperationHelper generateSimpleOperation,
                                       [FromKeyedServices(SettingHelperKeys.Addition)] IGetUserSetting settingHelper)
            : base(service,
                   generateSimpleOperation,
                   settingHelper)
        {
        }
    }
}
