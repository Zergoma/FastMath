using FastMath.Core.Abstraction;
using System;
using System.Collections.Generic;
using System.Text;

namespace FastMath.Core.Models.GenerateOperation
{
    public record GenerateOperationResult(
        OperationalBase Operation,
        EOperationMask Mask);
}
