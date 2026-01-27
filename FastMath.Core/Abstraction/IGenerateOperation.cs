using System;
using System.Collections.Generic;
using System.Text;

namespace FastMath.Core.Models.GenerateOperation
{
    public interface IGenerateOperation
    {
        GenerateOperationResult GenerateOperation(GenerateOperationParameters data);
        public List<SuggestedAnswer> GenerateSuggestedList(GenerateOperationResult data, GenerateOperationParameters OpData, int NbSuggestedItem);
    }
}
