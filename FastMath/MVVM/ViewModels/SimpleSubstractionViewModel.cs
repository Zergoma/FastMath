using FastMath.Core.Models.Operations;
using FastMath.Services;


namespace FastMath.MVVM.ViewModels
{
    public partial class SimpleSubstractionViewModel : SimpleOperationBaseViewModel
    {
        public SimpleSubstractionViewModel(SubstractionService service) : base()
        {
            OperationService = service;

            // We want the result of the subtraction to be positive
            // We force the service to provide us with values sorted in descending order
            service.BiggestOnLeft = true;
            GenerateNewOp();
        }
    }
}
