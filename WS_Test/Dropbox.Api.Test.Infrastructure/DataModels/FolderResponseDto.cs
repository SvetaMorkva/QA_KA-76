using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace TestDropboxApi.DataModels
{
    public class FolderResponseDto
    {
        [JsonProperty("metadata")]
        public FolderMetadata metadata { get; set; }

        [JsonProperty("metadata.name")]
        public string Name { get; set; }
        [JsonProperty("metadata.id")]
        public string Id { get; set; }
        [JsonProperty("metadata.path_lower")]
        public string PathLower { get; set; }
        [JsonProperty("metadata.path_display")]
        public string PathDisplay { get; set; }
    }

    public class FolderMetadata
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
