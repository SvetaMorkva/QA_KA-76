using Newtonsoft.Json;

namespace TestDropboxApi.DataModels
{
    // here is an example of parametric polymorphism, objects of the same class 
    // can be created in two ways that take different parameters
    public class UploadFileDto : Base
    {
        public UploadFileDto(string _path)
        {
            Path = _path;
            Mode = "add";
            Mute = false;
            AutoRename = true; 
        }

        public UploadFileDto(string _path, string _mode, bool _rename, bool _mute)
        {
            Path = _path;
            Mode = _mode;
            Mute = _mute;
            AutoRename = _rename;
        }

        [JsonProperty("mode")]
        public string Mode { get; set; }
        [JsonProperty("autorename")]
        public bool AutoRename { get; set; }
        [JsonProperty("mute")]
        public bool Mute { get; set; }
    }
}
