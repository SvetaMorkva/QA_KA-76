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
    public class DownloadRequest : RequestCommand
    {
        [JsonProperty("path")]
        public string Path { get; set; }


        public DownloadRequest()
        {
            RequestBuilder = new RequestBuilder(ConfigurationHelper.ContentServiceUrl);
        }


        public override HttpResponseMessage Execute()
        {
            string url = "files/download";
            var requestBody = JsonConvert.SerializeObject(this);
            return RequestBuilder.Method(HttpMethod.Post)
                            .Uri(url)
                            .WithHeader("Dropbox-API-Arg", requestBody)
                            .Execute();
        }
    }
}
