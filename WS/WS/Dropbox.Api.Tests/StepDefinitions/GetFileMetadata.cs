using System;
using System.IO;
using System.Reflection;
using FluentAssertions;
using TechTalk.SpecFlow;
using TestDropboxApi.ApiFacade;
using TestDropboxApi.DataModels;
using TestDropboxApi.Extensions;
using TestDropboxApi.Helpers;

namespace Dropbox.Api.Tests.StepDefinitions
{
    [Binding]
    public class GetFileListSteps
    {
        [Given(@"I have file '(.*)' in Dropbox")]
        public void GivenIHaveFileInDropbox(string fileName, UploadFileDto uploadFile)
        {
            var response = new DropboxApi().GetFilesList();
            response.EnsureSuccessful();
            var filesList = response.Content<FileListResponseDto>();
            bool flag = false;
            foreach (var file in filesList.Entries)
            {
                if (file.Name == fileName)
                {
                    flag = true;
                    ContextHelper.AddToContext("IdFile", file.Id);
                }
            }

            if (flag)
            {
                var filePath = GetFilePath(fileName);
                File.Exists(filePath)
                    .Should()
                    .BeTrue($"expected {fileName} to exists with test fata files inside the {filePath}");
                var file = File.ReadAllBytes(filePath);
                var responseUpload = new DropboxApiContent().UploadFile(uploadFile, file);
                responseUpload.EnsureSuccessful();
                var idFile = responseUpload.Content<FileResponseDto>().Id;
                ContextHelper.AddToContext("IdFile", idFile);
            }
        }
        
        [When(@"I get the file metadata")]
        public void WhenIGetTheFileMetadata()
        {
            var idFile = ContextHelper.GetFromContext<ApiResponse>("idFile");
            var response = new DropboxApi().GetFileMetadata(idFile.ContentAsString);
            ContextHelper.AddToContext("Metadata", response);
        }
        
        [Then(@"I should be able to get file info")]
        public void ThenIShouldBeAbleToGetFileInfo()
        {
            var response = ContextHelper.GetFromContext<ApiResponse>("Metadata");
            var idFile = ContextHelper.GetFromContext<ApiResponse>("idFile");
            var actualFileInfo = response.Content<FileResponseDto>();
            if(idFile.ContentAsString == actualFileInfo.Id)
            {
                bool flags = true;
            }

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
