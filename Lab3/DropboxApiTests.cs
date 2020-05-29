using NUnit.Framework;
using RestSharp;
using System;
using FluentAssertions;

namespace Lab3
{
    [TestFixture]
    public class DropboxApiTests 
    {
        private IRestClient client;
        private IRestResponse response;
        private IRestRequest request;
        private string token;

        [SetUp]
        public void RequestInit()
        {
            request = new RestRequest(Method.POST);
            token = Environment.GetEnvironmentVariable("DropboxToken");
        }

      

        [Test]
        public void GetMetadataRequestIsSuccessful()
        {
            client = new RestClient("https://api.dropboxapi.com/2/sharing/get_file_metadata")
            {
                Timeout = -1
            };
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Authorization", "Bearer " + token);
            request.AddParameter("application/json", "{\r\n    \"file\": \"/TestFolder/TestFile.pdf\",\r\n    \"actions\": []\r\n}", ParameterType.RequestBody);
            response = client.Execute(request);
            
            response.IsSuccessful.Should().BeTrue();

        }

        [Test]
        public void UploadFileRequestIsSuccessful()
        {
            client = new RestClient("https://content.dropboxapi.com/2/files/upload")
            {
                Timeout = -1
            };
            request.AddHeader("Dropbox-API-Arg", "{\"path\": \"/TestFolder/newFile.txt\",\"mode\": \"overwrite\",\"autorename\": true,\"mute\": false,\"strict_conflict\": false}");
            request.AddHeader("Content-type", "application/octet-stream");
            request.AddHeader("Authorization", "Bearer " + token);
            request.AddParameter("application/octet-stream", "--data-binary custom realization have taken:15miliseconds", ParameterType.RequestBody);
            response = client.Execute(request);
            
            response.IsSuccessful.Should().BeTrue();

        }

        [Test]
        public void DeleteFileRequestIsSuccessful()
        {
            client = new RestClient("https://api.dropboxapi.com/2/files/delete_v2")
            {
                Timeout = -1
            };
            request.AddHeader("Content-type", "application/json");
            request.AddHeader("Authorization", "Bearer " + token);
            request.AddParameter("application/json", "{\r\n    \"path\": \"/TestFolder/newFile.txt\"\r\n}", ParameterType.RequestBody);
            response = client.Execute(request);
            
            response.IsSuccessful.Should().BeTrue();

        }

    }
}
