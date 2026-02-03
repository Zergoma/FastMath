using FastMath.Infrastructure;

namespace FastMath.Serialization
{
    public class ConfigsJsonDataLayer<T> : JsonDataLayer<T> where T : class, new()
    {
        public ConfigsJsonDataLayer() : base(Constantes.UsersConfigurationPathJson())
        {
        }
    }
}
