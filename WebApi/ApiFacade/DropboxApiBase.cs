using System.Net.Http;
using Newtonsoft.Json;
using WebApi.Builders;
using WebApi.DataModels;
using WebApi.Helpers;

namespace WebApi.ApiFacade
{

    public class DropboxApiBase
    {
        protected RequestBuilder request;

        public virtual void CreateRequest()
        {
            request = null;
        }
    }
}
