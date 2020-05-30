using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
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

        public ApiResponse GetFileMetadata(string idFile)
        {
            const string url = "files/get_metadata";
            var body = new Base();
            body.Path = idFile;
            var requestBody = JsonConvert.SerializeObject(body);
            return request.Method(HttpMethod.Post).Uri(url).WithBody(requestBody).Execute();
        }

        public ApiResponse DeleteFile(string path)
        {
            const string url = "files/delete_v2";
            var body = new Base();
            body.Path = path;
            var requestBody = JsonConvert.SerializeObject(body);
            return request.Method(HttpMethod.Post).Uri(url).WithBody(requestBody).Execute();
        }
    }
}
