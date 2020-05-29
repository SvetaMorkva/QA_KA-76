using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApiTesting.DataModels
{
    class File
    {
        [JsonProperty("file")]
        public string FileID { get; set; } = string.Empty;
    }
}
