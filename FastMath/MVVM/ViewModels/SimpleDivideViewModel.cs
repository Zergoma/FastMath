using FastMath.Core.Models.OperandOption;
using FastMath.Services;


namespace FastMath.MVVM.ViewModels
{
    public partial class SimpleDivideViewModel : SimpleOperationBaseViewModel
    {
        public SimpleDivideViewModel(DivideService service) : base()
        {
            OperationService = service;
            OperandOption1 = new RandomOperandOption(Value: 10, zeroAuthorized: false);
            OperandOption2 = new RandomOperandOption(Value: 10, zeroAuthorized: false);
            GenerateNewOp();
        }
    }
}
