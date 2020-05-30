using Aropbox.Api.Tests.Infrastructure.DataModels;
using FluentAssertions;
using FluentAssertions.Execution;
using TechTalk.SpecFlow;
using TestDropboxApi.ApiFacade;
using TestDropboxApi.DataModels;
using TestDropboxApi.Helpers;

namespace Dropbox.Api.Tests.StepDefinitions
{
    [Binding]
    public class DeleteFileSteps
    {
        [When(@"I try to delete file '(.*)'")]
        public void WhenITryToDeleteFile(string fileName)
        {
            var response = new DropboxApi().DeleteItem(new Base($"/{fileName}"));
            response.EnsureSuccessful();
            ContextHelper.AddToContext("LastApiResponse", response);
        }
        
        [Then(@"I should be able to get file '(.*)' info")]
        public void ThenIShouldBeAbleToGetFileInfo(string fileName)
        {
            var apiResponse = ContextHelper.GetFromContext<ApiResponse>("LastApiResponse");
            var fileMetadata = apiResponse.Content<DeleteFileResponseDto>().Metadata;
            using (new AssertionScope())
            {
                fileMetadata.Should().NotBeNull();
                fileMetadata.Name.Should().Be(fileName);
            }
        }
        
        [Then(@"file '(.*)' should not be in list of existing files")]
        public void ThenFileShouldNotBeInListOfExistingFiles(string fileName)
        {
            var response = new DropboxApi().GetFilesList();
            response.EnsureSuccessful();
            var actualFileList = response.Content<FileListResponseDto>();

            using (new AssertionScope())
            {
                foreach (var FileInfo in actualFileList.Entries)
                    FileInfo.Name.Should().NotBe(fileName);
            }
        }
    }
}
