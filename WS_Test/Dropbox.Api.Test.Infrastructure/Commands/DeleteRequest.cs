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
    public class DeleteRequest : RequestCommand
    {
        [JsonProperty("path")]
        public string Path { get; set; }


        public DeleteRequest()
        {
            RequestBuilder = new RequestBuilder(ConfigurationHelper.ServiceUrl);
        }


        public override HttpResponseMessage Execute()
        {
            var url = "files/delete_v2";
            var requestBody = JsonConvert.SerializeObject(this);
            return RequestBuilder.Uri(url)
                            .Method(HttpMethod.Post)
                            .WithBody(requestBody)
                            .Execute();
        }
    }
}
