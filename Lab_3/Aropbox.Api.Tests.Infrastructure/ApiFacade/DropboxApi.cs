using Aropbox.Api.Tests.Infrastructure.DataModels;
using Newtonsoft.Json;
using System.Net.Http;
using TestDropboxApi.Builders;
using TestDropboxApi.DataModels;
using TestDropboxApi.Helpers;

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

        public ApiResponse GetFileMetadata(Base path)
        {
            const string url = "files/get_metadata";

            var requestBody = JsonConvert.SerializeObject(path);
            return request.Method(HttpMethod.Post).Uri(url)
                .WithBody(requestBody)
                .Execute();
        }

        public ApiResponse DeleteItem(Base path)
        {
            const string url = "files/delete_v2";

            var requestBody = JsonConvert.SerializeObject(path);
            return request.Method(HttpMethod.Post).Uri(url)
                .WithBody(requestBody)
                .Execute();
        }

        public ApiResponse CreateFolder(CreateFolderDto createFolder)
        {
            const string url = "files/create_folder_v2";
            var requestBody = JsonConvert.SerializeObject(createFolder);
            return request.Method(HttpMethod.Post).Uri(url)
                .WithBody(requestBody)
                .Execute();
        }
    }
}
