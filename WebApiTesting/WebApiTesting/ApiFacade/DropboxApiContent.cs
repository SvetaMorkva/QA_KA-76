using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using WebApiTesting.Builders;
using WebApiTesting.Helpers;

namespace WebApiTesting.ApiFacade
{
    public class DropboxApiContent
    {
        public RequestBuilder request;
        public DropboxApiContent()
        {
            request = new RequestBuilder(ConfigurationHelper.ContentServiceUrl);
        }
    }
}
