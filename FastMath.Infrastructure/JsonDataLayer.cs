using FastMath.Core.Interfaces;
using Newtonsoft.Json;

namespace FastMath.Infrastructure
{
    public class JsonDataLayer<T> : IDataLayer<T> where T : class, new()
    {
        public string Path { get; init; }

        public JsonDataLayer(string path)
        {
            Path = path;
        }
        public T Read()
        {
            if (File.Exists(Path) is false || new FileInfo(Path).Length == 0)
            {
                return new T();
            }
            
            return JsonConvert.DeserializeObject<T>(Path) ?? new T();
        }

        public void Write(T value)
        {
            string json = JsonConvert.SerializeObject(value, Formatting.Indented);
            File.WriteAllText(Path, json);
        }
    }
}
