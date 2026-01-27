using FastMath.Core.Helper;
using FastMath.Core.Models.OperandOption;
using FastMath.Services;


namespace FastMath.MVVM.ViewModels
{
    public partial class SimpleDivideViewModel : SimpleOperationBaseViewModel
    {
        public SimpleDivideViewModel(DivideService service, GenerateSimpleOperationHelper generateSimpleOperation)
            : base(service, generateSimpleOperation,
                  new RandomOperandOption(Value: 10, zeroAuthorized: false),
                  new RandomOperandOption(Value: 10, zeroAuthorized: false))
        {
        }
    }
}
