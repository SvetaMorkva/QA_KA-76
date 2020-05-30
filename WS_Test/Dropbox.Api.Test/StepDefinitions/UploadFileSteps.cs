using System;
using System.IO;
using System.Reflection;
using Dropbox.Api.Test.Infrastructure.Commands;
using Dropbox.Api.Test.Infrastructure.ResponseModels;
using FluentAssertions;
using NUnit.Framework;
using TechTalk.SpecFlow;
using TestDropboxApi.ApiFacade;
using TestDropboxApi.Extensions;
using TestDropboxApi.Helpers;

namespace Dropbox.Api.Test.StepDefinitions
{
    [Binding]
    public class UploadFileSteps
    {
        [Given(@"I have '(.*)' file to upload")]
        public void GivenIHaveFileToUpload(string fileName)
        {
            var filePath = GetFilePath(fileName);
            File.Exists(filePath)
                .Should()
                .BeTrue($"expected {fileName} to exists with test fata files inside the {filePath}");

            ContextHelper.AddToContext("FilePath", filePath);
        }


        [Given(@"I also have folder in Dropbox")]
        public void GivenIAlsoHaveFolderInDropbox(GetMetadataRequest request)
        {
            var response = new ApiResponse(request);
            response.EnsureSuccessful();

            var metadata = response.Content<MetadataDto>();

            Assert.AreEqual(request.Path, metadata.PathDisplay);
        }


        [When(@"I upload the file")]
        public void WhenIUploadTheFile(UploadRequest request)
        {
            string filePath = ContextHelper.GetFromContext<string>("FilePath");
            var file = File.ReadAllBytes(filePath);
            request.FileToUpload = file;

            var response = new ApiResponse(request);

            ContextHelper.AddToContext("LastApiResponse", response);
            ContextHelper.AddToContext("UploadRequest", request);
        }


        [Then(@"I should be able to get the valid upload file info")]
        public void ThenIShouldBeAbleToGetTheValidUploadFileInfo()
        {
            var response = ContextHelper.GetFromContext<ApiResponse>("LastApiResponse");
            var request = ContextHelper.GetFromContext<UploadRequest>("UploadRequest");

            var fileResponseDto = response.Content<FileMetadataDto>();

            Assert.AreEqual(request.Path, fileResponseDto.PathDisplay);
        }

        private string GetFilePath(string fileName)
        {
            string codeBase = Path.GetDirectoryName(Assembly.GetExecutingAssembly().CodeBase)
                              + Path.DirectorySeparatorChar
                              + ConfigurationHelper.DefaultFilePath;
            var uri = new UriBuilder(codeBase).Uri.Append(fileName);
            string fullPath = Path.GetFullPath(Uri.UnescapeDataString(uri.AbsolutePath));

            ScenarioContext.Current["DefaultFilePath"] = fullPath;
            return fullPath;
        }
    }
}
