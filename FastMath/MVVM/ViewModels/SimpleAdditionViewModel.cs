using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using FastMath.Core.Abstraction;
using FastMath.Core.Extension;
using FastMath.Core.Helper;
using FastMath.Core.Models;
using FastMath.Core.Models.OperandOption;
using FastMath.Services;
using ListShuffle;


namespace FastMath.MVVM.ViewModels
{
    public partial class SimpleAdditionViewModel : SimpleOperationBaseViewModel
    {
        public SimpleAdditionViewModel(AdditionService service) : base()
        {
            OperationService = service;
            GenerateNewOp();
        }
    }
}
