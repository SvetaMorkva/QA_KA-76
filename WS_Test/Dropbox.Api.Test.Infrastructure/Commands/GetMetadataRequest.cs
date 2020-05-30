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
    public class GetMetadataRequest : RequestCommand
    {
        [JsonProperty("path")]
        public string Path { get; set; }

        [JsonProperty("include_media_info")]
        public bool IncludeMediaInfo { get; set; }

        [JsonProperty("include_deleted")]
        public bool IncludeDeleted { get; set; }

        [JsonProperty("include_has_explicit_shared_members")]
        public bool IncludeHasExplicitSharedMembers { get; set; }


        public GetMetadataRequest()
        {
            RequestBuilder = new RequestBuilder(ConfigurationHelper.ServiceUrl);
        }


        public override HttpResponseMessage Execute()
        {
            string url = "files/get_metadata";
            var requestBody = JsonConvert.SerializeObject(this);
            return RequestBuilder.Method(HttpMethod.Post)
                            .Uri(url)
                            .WithBody(requestBody)
                            .Execute();
        }
    }
}
