using FastMath.Core.Models;

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
            
            int nbElem = availableValues.Length;

            return nbElem switch
            {
                0 => throw new InvalidOperationException("No available EOperationMask values after blacklist."),
                1 => availableValues[0],
                _ => availableValues[Rdm.Next(nbElem)],
            };
        }
    }
}
