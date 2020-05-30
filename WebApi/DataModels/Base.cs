using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace WebApi.DataModels
{
    public class Base
    {
        [JsonProperty("path")]
        public string Path { get; set; } = string.Empty;
    }
}
