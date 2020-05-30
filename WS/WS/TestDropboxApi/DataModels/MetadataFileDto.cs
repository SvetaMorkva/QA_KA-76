using Newtonsoft.Json;

namespace TestDropboxApi.DataModels
{
    class MetadataFileDto
    {
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("path_lower")]
        public string PathLower { get; set; }
        [JsonProperty("path_display")]
        public string PathDisplay { get; set; }
    }
}
