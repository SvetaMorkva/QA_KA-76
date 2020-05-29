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

        public ApiResponse DeleteFile(string file_path)
        {
            Base f_path = new Base();
            f_path.Path = file_path;

            const string url = "files/delete_v2";
            var requestBody = JsonConvert.SerializeObject(f_path);
            return request.Uri(url).Method(HttpMethod.Post).WithBody(requestBody).Execute();
        }

        public ApiResponse FileMetadata(string fileName)
        {

            const string url = "files/get_metadata";
            var f_path = new Base();
            f_path.Path = $"/{fileName}";
            var requestBody = JsonConvert.SerializeObject(f_path);
            return request.Method(HttpMethod.Post).Uri(url).WithBody(requestBody).Execute();
            
        }
    }
}
