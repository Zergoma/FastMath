using FastMath.Core.Models.OperandOption;
using FastMath.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace FastMath.MVVM.ViewModels
{

    public partial class SimpleMultiplyViewModel : SimpleOperationBaseViewModel
    {
        public SimpleMultiplyViewModel(MultiplicationService service) : base()
        {
            OperationService = service;
            OperandOption1 = new RandomOperandOption(Value: 10, zeroAuthorized:false);
            OperandOption2 = new RandomOperandOption(Value: 10, zeroAuthorized: false);
            GenerateNewOp();
        }
    }
}
