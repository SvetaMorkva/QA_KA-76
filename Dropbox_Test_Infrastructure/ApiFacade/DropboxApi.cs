using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using TestDropboxApi.Builders;
using TestDropboxApi.Helpers;
using TestDropboxApi.DataModels;

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
            const string url = "sharing/get_file_metadata";
            FileMetadata metadata = new FileMetadata();
            metadata.File = filename;
            var requestBody = JsonConvert.SerializeObject(metadata);
            return request.Method(HttpMethod.Post).Uri(url).WithBody(requestBody).Execute();
        }

        public ApiResponse DeleteFile(string filename)
        {
            const string url = "files/delete_v2";
            Base file = new Base();

            file.Path = filename;

            var requestBody = JsonConvert.SerializeObject(file);
            return request.Method(HttpMethod.Post).Uri(url).WithBody(requestBody).Execute();
        }
    }
}
