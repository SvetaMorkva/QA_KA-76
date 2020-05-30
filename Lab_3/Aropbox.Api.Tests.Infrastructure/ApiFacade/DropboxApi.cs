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
using Aropbox.Api.Tests.Infrastructure.DataModels;

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
            return request.Method(HttpMethod.Post).Uri(url)
                .WithBody(requestBody)
                .Execute();
        }

        public ApiResponse GetFileMetadata(string fileName)
        {
            const string url = "files/get_metadata";
            var path = new Base();
            path.Path = $"/{fileName}";
            var requestBody = JsonConvert.SerializeObject(path);
            return request.Method(HttpMethod.Post).Uri(url)
                .WithBody(requestBody)
                .Execute();
        }

        public ApiResponse DeleteFile(string fileName)
        {
            var url = "files/delete_v2";
            var path = new Base();
            path.Path = $"/{fileName}";
            var requestBody = JsonConvert.SerializeObject(path);
            return request.Method(HttpMethod.Post).Uri(url)
                .WithBody(requestBody)
                .Execute();
        }

        public ApiResponse CreateFolder(CreateFolderDto createFolder)
        {
            var url = "files/create_folder_v2";
            var requestBody = JsonConvert.SerializeObject(createFolder);
            return request.Method(HttpMethod.Post).Uri(url)
                .WithBody(requestBody)
                .Execute();
        }
    }
}
