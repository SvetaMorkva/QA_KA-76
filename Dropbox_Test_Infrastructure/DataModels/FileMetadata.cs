using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestDropboxApi.DataModels
{
    public class FileMetadata
    {
        [JsonProperty("file")]
        public string File { get; set; }
    }

    public class FileMetaResponseDto
    {
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("preview_url")]
        public string PreviewUrl { get; set; }
    }
}
