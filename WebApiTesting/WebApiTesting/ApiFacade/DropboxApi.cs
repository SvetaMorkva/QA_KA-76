using Newtonsoft.Json;
using System.Net.Http;
using WebApiTesting.Builders;
using WebApiTesting.DataModels;
using WebApiTesting.Helpers;

namespace WebApiTesting.ApiFacade
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
            var requestBody = JsonConvert.SerializeObject(new FilePath());
            return request.Method(HttpMethod.Post).Uri(url).WithBody(requestBody).Execute();
        }

        public ApiResponse DeleteFile(string file_path)
        {
            FilePath path = new FilePath();
            path.Path = file_path;

            const string url = "files/delete_v2";
            var requestBody = JsonConvert.SerializeObject(path);
            return request.Uri(url)
                .Method(HttpMethod.Post)
                .WithBody(requestBody)
                .Execute();
        }

        public ApiResponse GetFileMetadata(string fileID)
        {
            File data = new File();
            data.FileID = fileID;

            string url = "sharing/get_file_metadata";
            var requestBody = JsonConvert.SerializeObject(data);
            return request.Method(HttpMethod.Post)
                            .Uri(url)
                            .WithBody(requestBody)
                            .Execute();
        }

    }
}
