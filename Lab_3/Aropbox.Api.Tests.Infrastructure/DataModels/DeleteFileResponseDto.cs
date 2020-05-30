using Newtonsoft.Json;
using TestDropboxApi.DataModels;

namespace Aropbox.Api.Tests.Infrastructure.DataModels
{
    public class DeleteFileResponseDto
    {
        [JsonProperty("metadata")]
        public FileMetadataResponseDto Metadata { get; set; }
    }
}
