using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dropbox.Api.Test.Infrastructure.DataModels;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace TestDropboxApi.DataModels
{
    public class FolderResponseDto
    {
        [JsonProperty("metadata")]
        public Metadata Metadata { get; set; }
    }
}
