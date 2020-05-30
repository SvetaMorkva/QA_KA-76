using Dropbox.Api.Tests.StepDefinitions;
using FluentAssertions;
using TechTalk.SpecFlow;
using TestDropboxApi.ApiFacade;
using TestDropboxApi.DataModels;
using TestDropboxApi.Helpers;

namespace Dropbox_Test.StepDefinitions
{
    [Binding]
    public class DeleteFileSteps : FileTestBase
    {
        [When(@"I try to delete '(.*)' file")]
        public void WhenITryToDeleteFile(string filename)
        {
            GetFile(filename).UploadFile().CheckFileInfo();
            var response = new DropboxApi().DeleteFile(filename);
            response.EnsureSuccessful();
            ContextHelper.AddToContext("LastApiResponse", response);
        }
        
        [Then(@"I should get a valid file info")]
        public void ThenIShouldGetAValidFileInfo(FileResponseDto validData)
        {

            var apiResponse = ContextHelper.GetFromContext<ApiResponse>("LastApiResponse");
            var actualData = apiResponse.GetMetadataInJson().Content<FileResponseDto>();

            actualData.Should().NotBeNull();
            actualData.Name.ShouldBeEquivalentTo(validData.Name);
        }
    }
}
