using Newtonsoft.Json;

namespace WebApiTesting.DataModels
{
    class File
    {
        [JsonProperty("file")]
        public string FileID { get; set; } = string.Empty;
    }
}
