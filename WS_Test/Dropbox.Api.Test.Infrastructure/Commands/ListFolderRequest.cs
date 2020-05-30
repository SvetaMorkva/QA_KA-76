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
    public class ListFolderRequest : RequestCommand
    {
        [JsonProperty("path")]
        public string Path { get; set; }

        [JsonProperty("recursive")]
        public bool Recursive { get; set; }

        [JsonProperty("include_media_info")]
        public bool IncludeMediaInfo { get; set; }

        [JsonProperty("include_deleted")]
        public bool IncludeDeleted { get; set; }

        [JsonProperty("include_has_explicit_shared_members")]
        public bool IncludeHasExplicitSharedMembers { get; set; }

        [JsonProperty("include_mounted_folders")]
        public bool IncludeMountedFolders { get; set; }

        [JsonProperty("include_non_downloadable_files")]
        public bool IncludeNonDownloadableFiles { get; set; }


        public ListFolderRequest()
        {
            RequestBuilder = new RequestBuilder(ConfigurationHelper.ServiceUrl);
        }

        public override HttpResponseMessage Execute()
        {
            string url = "files/list_folder";
            var requestBody = JsonConvert.SerializeObject(this);
            return RequestBuilder.Method(HttpMethod.Post)
                            .Uri(url)
                            .WithBody(requestBody)
                            .Execute();
        }
    }
}
