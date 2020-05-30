using System;
using System.Net.Http;
using Newtonsoft.Json;
using WebApi.DataModels;
using WebApi.Helpers;
using WebApi.Builders;

namespace WebApi.ApiFacade
{
    public class DropboxApi
    {
        public RequestBuilder request;
        public DropboxApi()
        {
            request = new RequestBuilder(ConfigurationHelper.ServiceUrl);
        }

        public ApiResponse DeleteFile(string file_path)
        {
            Base path = new Base();
            path.Path = file_path;

            const string url = "files/delete_v2";
            var requestBody = JsonConvert.SerializeObject(path);
            return request.Uri(url).Method(HttpMethod.Post).WithBody(requestBody).Execute();
        }

        public ApiResponse GetFileMetadata(string file_path)
        {
            Base path = new Base();
            path.Path = file_path;

            string url = "files/get_metadata";
            var requestBody = JsonConvert.SerializeObject(path);
            return request.Method(HttpMethod.Post).Uri(url).WithBody(requestBody).Execute();
        }
    }
}
