using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TestDropboxApi.Builders;
using TestDropboxApi.Helpers;

namespace Dropbox.Api.Test.Infrastructure.Commands
{
    public class UploadRequest : RequestCommand
    {
        [JsonProperty("path")]
        public string Path { get; set; }

        [JsonProperty("mode")]
        public string Mode { get; set; }

        [JsonProperty("autorename")]
        public bool Autorename { get; set; }

        [JsonProperty("mute")]
        public bool Mute { get; set; }

        [JsonProperty("strict_conflict")]
        public bool StrictConflict { get; set; }

        [JsonIgnore]
        public byte[] FileToUpload { get; set; }


        public UploadRequest()
        {
            RequestBuilder = new RequestBuilder(ConfigurationHelper.ContentServiceUrl);
        }


        public override HttpResponseMessage Execute()
        {
            var url = "files/upload";
            var requestBody = JsonConvert.SerializeObject(this);
            return RequestBuilder.Uri(url)
                                .Method(HttpMethod.Post)
                                .WithHeader("Dropbox-API-Arg", requestBody)
                                .WithFile(FileToUpload)
                                .Execute();
        }
    }
}
