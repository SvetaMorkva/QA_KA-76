using System;
using System.IO;
using System.Reflection;
using NUnit;
using NUnit.Framework;
using FluentAssertions;
using TechTalk.SpecFlow;
using TestDropboxApi.ApiFacade;
using TestDropboxApi.DataModels;
using TestDropboxApi.Extensions;
using TestDropboxApi.Helpers;

namespace Test.StepDefinitons
{
    [Binding]
    public class DropboxSteps
    {
        [Given(@"I have file '(.*)' in Dropbox")]
        public void GivenIHaveFileInDropbox(string fileName, Table table)
        {
            var rows = table.Rows;
            var uploadFile = new UploadFileDto();
            foreach (var r  in rows)
            {
                uploadFile.Path = r[0];
                uploadFile.Mode = r[1];
                uploadFile.AutoRename = r[2] == "true" ? true : false;
                uploadFile.Mute = r[3] == "false" ? false : true;
            }
            var response = new DropboxApi().GetFilesList();
            response.EnsureSuccessful();
            var filesList = response.Content<FileListResponseDto>();
            bool flag = false;
            foreach (var file in filesList.Entries)
            {
                if (file.Name == fileName)
                {
                    flag = true;
                    ContextHelper.AddToContext("File", file);
                }
            }

            if (!flag)
            {
                var filePath = GetFilePath(fileName);
                File.Exists(filePath)
                    .Should()
                    .BeTrue($"expected {fileName} to exists with test fata files inside the {filePath}");
                var file = File.ReadAllBytes(filePath);
                var responseUpload = new DropboxApiContent().UploadFile(uploadFile, file);
                responseUpload.EnsureSuccessful();
                var responseFile = responseUpload.Content<FileResponseDto>();
                ContextHelper.AddToContext("File", responseFile);
            }
        }
        
        [When(@"I get the file metadata")]
        public void WhenIGetTheFileMetadata()
        {
            var file = ContextHelper.GetFromContext<FileResponseDto>("File");
            var response = new DropboxApi().GetFileMetadata(file.Id);
            ContextHelper.AddToContext("Metadata", response);
        }
        
        [Then(@"I should be able to get file info")]
        public void ThenIShouldBeAbleToGetFileInfo()
        {
            var response = ContextHelper.GetFromContext<ApiResponse>("Metadata");
            var file = ContextHelper.GetFromContext<FileResponseDto>("File");
            var actualFileInfo = response.Content<FileResponseDto>();
            Assert.AreEqual(file.Id, actualFileInfo.Id);
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
