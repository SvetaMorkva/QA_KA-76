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

        public ApiResponse GetFilesList(Base path)
        {
            const string url = "files/list_folder";
            var requestBody = JsonConvert.SerializeObject(path);
            return request.Method(HttpMethod.Post)
                            .Uri(url)
                            .WithBody(requestBody)
                            .Execute();
        }

        public ApiResponse GetFileMetadata(Base path)
        {
            string url = "files/get_metadata";
            var requestBody = JsonConvert.SerializeObject(path);
            return request.Method(HttpMethod.Post)
                            .Uri(url)
                            .WithBody(requestBody)
                            .Execute();
        }

        public ApiResponse CreateFolder(CreateFolderDto createFolderDto)
        {
            var url = "files/create_folder_v2";
            var requestBody = JsonConvert.SerializeObject(createFolderDto);
            return request.Uri(url)
                .Method(HttpMethod.Post)
                .WithBody(requestBody)
                .Execute();
        }


        public ApiResponse DeleteFolder(Base path)
        {
            var url = "files/delete_v2";
            var requestBody = JsonConvert.SerializeObject(path);
            return request.Uri(url)
                .Method(HttpMethod.Post)
                .WithBody(requestBody)
                .Execute();
        }
    }
}
