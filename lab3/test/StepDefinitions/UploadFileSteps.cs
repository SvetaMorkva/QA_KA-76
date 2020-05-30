using System;
using System.IO;
using System.Reflection;
using FluentAssertions;
using TechTalk.SpecFlow;
using TestDropboxApi.ApiFacade;
using TestDropboxApi.DataModels;
using TestDropboxApi.Extensions;
using TestDropboxApi.Helpers;
using Xunit;

// The bindings (step definitions, hooks, etc.) provide the connection between your
// feature files and application interfaces. For more details follow the link below:
// https://specflow.org/documentation/step-definitions/

// namespace Dropbox.Api.Tests.StepDefinitions
namespace test.StepDefinitions
{
    public class FileData // the POCO for sharing file data
    {
        public string fileName;
    }

    [Binding]
    public class UploadFileSteps
    {
        private readonly FileData fileData;
        public UploadFileSteps(FileData fileData)
        {
            /*
            The POCO is defined for holding the data of a person and use it in a given and 
            a then step that are placed in different binding classes.
            */
            this.fileData = fileData;
        }

        [Given(@"I have '(.*)' file to upload")]
        public void GivenIHaveFileToUpload(string fileName)
        {
            fileData.fileName = fileName;

            var filePath = GetFilePath(fileData.fileName);
            File.Exists(filePath)
                .Should()
                .BeTrue($"expected {fileName} to exists with test fata files inside the {filePath}");
            
            ContextHelper.AddToContext("FilePath", filePath);
        }
    
        [When(@"I upload the file")]
        public void WhenIUploadTheFile(UploadFileDto uploadFile)
        {
            var filePath = ContextHelper.GetFromContext<string>("FilePath");
            var file = File.ReadAllBytes(filePath);
            var response = new DropboxApiContent().UploadFile(uploadFile, file);
            response.EnsureSuccessful();
            ContextHelper.AddToContext("LastApiResponse", response);
        }

        // [Fact]
        [Then(@"I should be able to get file info")]
        public void ThenIShouldBeAbleToGetFileInfo(FileResponseDto fileInfo)
        {
            var apiResponse = ContextHelper.GetFromContext<ApiResponse>("LastApiResponse");
            var actualFileInfo = apiResponse.Content<FileResponseDto>();

            actualFileInfo.ShouldBeEquivalentTo(fileInfo, options => options.Including(f => f.Name));
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
