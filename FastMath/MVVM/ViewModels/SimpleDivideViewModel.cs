using FastMath.Core.Helpers;
using FastMath.Core.Interfaces;
using FastMath.Helper;
using FastMath.Services;


namespace FastMath.MVVM.ViewModels
{
    public partial class SimpleDivideViewModel
        : SimpleOperationBaseViewModel
    {
        public SimpleDivideViewModel([FromKeyedServices(OperationServiceKeys.Division)]IGetOperation service,
                                     GenerateSimpleOperationHelper generateSimpleOperation,
                                     [FromKeyedServices(SettingHelperKeys.Division)] IGetUserSetting settingHelper)
            : base(service,
                   generateSimpleOperation,
                   settingHelper)
        {
        }
    }
}