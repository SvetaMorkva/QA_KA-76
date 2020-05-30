using Newtonsoft.Json;

namespace TestDropboxApi.DataModels
{
    public class Base
    {
        [JsonProperty("path")]
        public string Path { get; set; }

        public Base()
        {
            this.Path = string.Empty;
        }

        public Base(string Path)
        {
            this.Path = Path;
        }

        
    }
}
