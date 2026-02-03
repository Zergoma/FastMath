using FastMath.Core.Interfaces;
using FastMath.Core.Models.OperationsWorld.OperationParameters;
using FastMath.Core.Models.OperationsWorld.OperationParameters.Types;

namespace FastMath.Core.Factories
{
    public class OriginParametersFactory : ICreate<OperationSettingParametersBase>
    {
        static readonly Dictionary<Type, IOperationSettingFactory> factories = new()
        {
            { typeof(AdditionSimpleParameters), new AdditionSimpleParametersFactory() },
            { typeof(DivideSimpleParameters), new DivideSimpleParametersFactory() },
            { typeof(MultiplySimpleParameters), new MultiplySimpleParametersFactory() },
            { typeof(SubstractSimpleParameters), new SubstractSimpleParametersFactory() },
        };

        public OperationSettingParametersBase Create(Type elementType)
        {
            return factories[elementType]?.Create() 
                ?? throw new OperationCreationFactoryException($"No usine parameter factory for this type {elementType}");
        }
    }
}
