using Newtonsoft.Json;
using TestDropboxApi.DataModels;

namespace Aropbox.Api.Tests.Infrastructure.DataModels
{
    public class CreateFolderDto: Base
    {
        [JsonProperty("autorename")]
        public bool AutoRename { get; set; }

    }
}
