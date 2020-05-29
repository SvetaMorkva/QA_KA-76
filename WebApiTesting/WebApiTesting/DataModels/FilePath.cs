using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApiTesting.DataModels
{
    public class FilePath
    {
        [JsonProperty("path")]
        public string Path { get; set; } = string.Empty;
    }
}
