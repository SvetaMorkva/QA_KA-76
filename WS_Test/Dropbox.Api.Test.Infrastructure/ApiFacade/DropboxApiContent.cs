using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using TestDropboxApi.Builders;
using TestDropboxApi.DataModels;
using TestDropboxApi.Helpers;

namespace TestDropboxApi.ApiFacade
{
    public class DropboxApiContent
    {
        public RequestBuilder request;
        public DropboxApiContent()
        {
            request = new RequestBuilder(ConfigurationHelper.ContentServiceUrl);
        }
        public ApiResponse UploadFile(UploadFileDto uploadDto, byte[] file)
        {
            var url = "files/upload";
            var requestBody = JsonConvert.SerializeObject(uploadDto);
            return request.Uri(url).Method(HttpMethod.Post)
                .WithHeader("Dropbox-API-Arg", requestBody)
                .WithFile(file)
                .Execute();
        }

        public ApiResponse DownloadFile(Base path)
        {
            string url = "files/download";
            var requestBody = JsonConvert.SerializeObject(path);
            return request.Method(HttpMethod.Post)
                            .Uri(url)
                            .WithHeader("Dropbox-API-Arg", requestBody)
                            .Execute();
        }
    }
}
