﻿using Newtonsoft.Json;

namespace TestDropboxApi.DataModels
{
    public class UploadFileDto : Base // принцип ооп - наследование 
    {
        [JsonProperty("mode")]
        public string Mode { get; set; }
        [JsonProperty("autorename")]
        public bool AutoRename { get; set; }
        [JsonProperty("mute")]
        public bool Mute { get; set; }
    }
}
