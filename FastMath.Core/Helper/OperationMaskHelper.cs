using FastMath.Core.Models;
using System;
using System.Collections.Generic;
using System.Runtime.Intrinsics.Arm;
using System.Text;

namespace FastMath.Core.Helper
{
    static public class OperationMaskHelper
    {
        static readonly Random Rdm = Random.Shared;

        private static readonly HashSet<EOperationMask> AlwaysExcluded =
        [
            EOperationMask.none
        ];

        public static EOperationMask CreateRandomMask(params EOperationMask[] blacklisted)
        {
            var availableValues = Enum.GetValues<EOperationMask>()
                .Except(AlwaysExcluded)
                .Except(blacklisted)
                .ToArray();

            if (availableValues.Length == 0)
            {
                throw new InvalidOperationException(
                    "No available EOperationMask values after blacklist.");
            }

            int index = Rdm.Next(availableValues.Length);
            return availableValues[index];
        }
    }
}
