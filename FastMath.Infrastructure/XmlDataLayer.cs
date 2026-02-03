using FastMath.Core.Interfaces;
using System.Diagnostics;
using System.Xml.Serialization;

namespace FastMath.Infrastructure
{
    public class XmlDataLayer<T> : IDataLayer<T> where T : class, new()
    {
        public XmlDataLayer(string path)
        {
            Path = path;
            Debug.WriteLine($"Users Configuration file location: {path}");
        }

        public string Path { get; init; }

        public T Read()
        {
            if (!File.Exists(Path) || new FileInfo(Path).Length == 0)
            {
                // first init time
                return new T();
            }

            using FileStream userFileStream = File.Open(Path, FileMode.OpenOrCreate);
            
            XmlSerializer xmlDeserializer = new (typeof(T));

            return xmlDeserializer.Deserialize(userFileStream) as T ?? new T();
        }

        public void Write(T value)
        {
            using FileStream userFileStream = File.Open(Path, FileMode.OpenOrCreate);
            XmlSerializer xmlDeserializer = new(typeof(T));
            xmlDeserializer.Serialize(userFileStream, value);
        }
    }
}
