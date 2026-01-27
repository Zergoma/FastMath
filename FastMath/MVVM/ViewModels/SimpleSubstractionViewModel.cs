using FastMath.Core.Helper;
using FastMath.Core.Models.Operations;
using FastMath.Services;


namespace FastMath.MVVM.ViewModels
{
    public partial class SimpleSubstractionViewModel : SimpleOperationBaseViewModel
    {
        public SimpleSubstractionViewModel(SubstractionServiceBiggestOnLeft service, GenerateSimpleOperationHelper generateSimpleOperation)
            : base(service, generateSimpleOperation)
        {

        }
    }
}
