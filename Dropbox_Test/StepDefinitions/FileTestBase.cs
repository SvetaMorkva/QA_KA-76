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
    // I use this class as a base, so all public methods are available to me in its descendants
    // but there is also a private method GetFilePath, this is a helper method, 
    // which is needed only inside this class
    // this is one example of an encapsulation paradigm
    public class FileTestBase
    {
        public FileTestBase GetFile(string fileName)
        {
            _fileName = fileName;
            var filePath = GetFilePath(fileName);
            File.Exists(filePath)
                .Should()
                .BeTrue($"expected {fileName} to exists with test fata files inside the {filePath}");
            
            ContextHelper.AddToContext("FilePath", filePath);
            return this;
        }

        public FileTestBase UploadFile()
        {
            var filePath = ContextHelper.GetFromContext<string>("FilePath");
            var file = File.ReadAllBytes(filePath);
            var response = new DropboxApiContent().UploadFile(new UploadFileDto(_fileName), file);
            response.EnsureSuccessful();
            ContextHelper.AddToContext("LastApiResponse", response);
            return this;
        }

        public FileTestBase CheckFileInfo()
        {
            var apiResponse = ContextHelper.GetFromContext<ApiResponse>("LastApiResponse");
            var actualFileInfo = apiResponse.Content<FileResponseDto>();


            actualFileInfo.Name.ShouldBeEquivalentTo(_fileNameInfo);
            return this;
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

        private string _fileName;
        private string _fileNameInfo = "MyImage_.jpg";
    }
}
