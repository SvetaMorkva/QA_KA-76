using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestDropboxApi.DataModels;

namespace Aropbox.Api.Tests.Infrastructure.DataModels
{
    public class CreateFolderDto: Base
    {
        [JsonProperty("autorename")]
        public bool AutoRename { get; set; }

    }
}
