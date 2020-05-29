using Newtonsoft.Json;

namespace WebApiTesting.DataModels
{
    public class FilePath
    {
        [JsonProperty("path")]
        public string Path { get; set; } = string.Empty;
    }
}
