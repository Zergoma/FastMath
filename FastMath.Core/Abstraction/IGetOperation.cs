using FastMath.Core.Models;
using FastMath.Core.Models.Operations;
using System;
using System.Collections.Generic;
using System.Text;

namespace FastMath.Core.Abstraction
{
    public interface IGetOperation
    {
        public OperationalBase CreateOperation(OperandOptionBase optionOperand1, OperandOptionBase optionOperand2);
    }
}
