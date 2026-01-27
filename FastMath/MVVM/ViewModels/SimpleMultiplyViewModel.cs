using FastMath.Core.Helper;
using FastMath.Core.Models.OperandOption;
using FastMath.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace FastMath.MVVM.ViewModels
{

    public partial class SimpleMultiplyViewModel : SimpleOperationBaseViewModel
    {
        public SimpleMultiplyViewModel(MultiplicationService service, GenerateSimpleOperationHelper generateSimpleOperation)
            : base(service, generateSimpleOperation,
                  new RandomOperandOption(Value: 10, zeroAuthorized: false),
                  new RandomOperandOption(Value: 10, zeroAuthorized: false))
        {

        }
    }
}
