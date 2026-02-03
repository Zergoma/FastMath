using FastMath.Core.Models;
using FastMath.Core.Models.OperationsWorld.GenerateOperation;

namespace FastMath.Core.Interfaces
{
    public interface IGenerateOperation
    {
        GenerateOperationResult GenerateOperation(GenerateOperationParameters data);
        public List<SuggestedAnswer> GenerateSuggestedList(GenerateOperationResult data, GenerateOperationParameters OpData, int NbSuggestedItem);
    }
}
