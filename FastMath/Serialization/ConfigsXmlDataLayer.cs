using FastMath.Infrastructure;

namespace FastMath.Serialization
{
    public class ConfigsXmlDataLayer<T> : XmlDataLayer<T> where T : class, new()
    {
        public ConfigsXmlDataLayer() : base(Constantes.UsersConfigurationPathXml())
        {
            
        }
    }
}
