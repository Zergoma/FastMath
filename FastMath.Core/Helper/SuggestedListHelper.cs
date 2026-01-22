using FastMath.Core.Models;
using System.Diagnostics;

namespace FastMath.Core.Helper
{
    static public class SuggestedListHelper
    {
        static private readonly Random rdm = Random.Shared;
        static public void GenerateList(int nbVal, List<SuggestedAnswer> resu, Decimal max)
        {
            // get the decimal number
            var decimalcount = BitConverter.GetBytes(decimal.GetBits(max)[3])[2];

            int guard = 0;
            int maxTry = 100;

            while (resu.Count < nbVal && guard++ < maxTry)
            {
                var next = GetValue(max, decimalcount);

                if (resu.All(x => x.Value != next))
                {
                    resu.Add(new() { Value = next });
                    guard = 0;
                }
            }
        }

        static private Decimal GetValue(Decimal Max, uint nbDecimal)
        {
            Decimal val = (decimal)rdm.NextDouble() * Max;
            val = Math.Round(val, (int)nbDecimal);
            return val;
        }
    }
}
