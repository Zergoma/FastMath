using FastMath.Core.Models;
using System;
using System.Collections.Generic;
using System.Runtime.Intrinsics.Arm;
using System.Text;

namespace FastMath.Core.Helper
{
    static public class OperationMaskHelper
    {
        static readonly Random rdm = Random.Shared;
        static public EOperationMask CreateRandomMask()
        {
            int val = rdm.Next(3);
            return val switch
            {
                0 => EOperationMask.left,
                1 => EOperationMask.right,
                2 => EOperationMask.result,
                3 => EOperationMask.none,
                _ => EOperationMask.result,
            };
        }
    }
}
