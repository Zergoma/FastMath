using FastMath.Core.Enums;
using FastMath.Core.Extensions;
using FastMath.Core.Interfaces;
using FastMath.Core.Models;
using FastMath.Core.Models.OperationsWorld.GenerateOperation;
using ListShuffle;

namespace FastMath.Core.Helpers
{
    public class GenerateSimpleOperationHelper : IGenerateOperation
    {
        public GenerateOperationResult GenerateOperation(GenerateOperationParameters opData)
        {
            var operation = opData.OpService.CreateOperation(opData.LeftOperandOption, opData.RightOperandOption);

            EOperationMask opMask = OperationMaskHelper.CreateRandomMask(operation.FiltreMask());

            return new(operation, opMask);
        }

        public List<SuggestedAnswer> GenerateSuggestedList(GenerateOperationResult data, GenerateOperationParameters opData, int nbSuggestedItem)
        {
            List<SuggestedAnswer> resu = new()
            {
                new(){ Value = data.Operation.GetOffuscatedValue(data.Mask), IsGoodSolution = true},
            };

            SuggestedListHelper.GenerateList(nbSuggestedItem,
                                             resu,
                                             data.Operation.GetOffuscatedValueMax(data.Mask, opData.LeftOperandOption, opData.RightOperandOption));

            resu.Shuffle();
            return resu;
        }
    }
}
