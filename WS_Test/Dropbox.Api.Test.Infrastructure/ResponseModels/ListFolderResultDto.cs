using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dropbox.Api.Test.Infrastructure.ResponseModels
{
    public class ListFolderResultDto
    {
        [JsonProperty("entries")]
        public List<FileMetadataDto> Entries { get; set; }
        [JsonProperty("cursor")]
        public string Cursor { get; set; }
        [JsonProperty("has_more")]
        public bool HasMore { get; set; }
    }
}
