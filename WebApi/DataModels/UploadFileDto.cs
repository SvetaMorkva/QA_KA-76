using Newtonsoft.Json;

namespace WebApi.DataModels
{
    // Наследование 
    public class UploadFileDto : Base
    {
        [JsonProperty("mode")]
        public string Mode { get; set; }
        [JsonProperty("autorename")]
        public bool AutoRename { get; set; }
        [JsonProperty("mute")]
        public bool Mute { get; set; }
    }
}
