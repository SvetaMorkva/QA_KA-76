using System.Net.Http;
using Newtonsoft.Json;
using TestDropboxApi.DataModels;
using TestDropboxApi.Helpers;
using TestDropboxApi.Builders;

namespace TestDropboxApi.ApiFacade
{
    public class DropboxApi
    {
        public RequestBuilder request;
        public DropboxApi()
        {
            request = new RequestBuilder(ConfigurationHelper.ServiceUrl);
        }

        public ApiResponse GetFilesList()
        {
            const string url = "files/list_folder";
            var requestBody = JsonConvert.SerializeObject(new Base());
            return request.Method(HttpMethod.Post).Uri(url).WithBody(requestBody).Execute();
        }

        public ApiResponse GetFileMetadata(string filename)
        {
            const string url = "files/get_metadata";
            var baseObj = new Base
            {
                Path = "/" + filename
            };
            var requestBody = JsonConvert.SerializeObject(baseObj);
            return request.Method(HttpMethod.Post).Uri(url).WithBody(requestBody).Execute();
        }

        public ApiResponse DeleteFile (string filename)
        {
            const string url = "files/delete_v2";
            var baseObj = new Base
            {
                Path = "/" + filename
            };
            var requestBody = JsonConvert.SerializeObject(baseObj);
            return request.Method(HttpMethod.Post).Uri(url).WithBody(requestBody).Execute();
        }
    }
}
