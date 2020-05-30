using TechTalk.SpecFlow;
using TestDropboxApi.ApiFacade;
using TestDropboxApi.Helpers;
using TestDropboxApi.DataModels;
using FluentAssertions;
using Dropbox.Api.Tests.StepDefinitions;

namespace Dropbox_Test.StepDefinitions
{
    // used a base class for tests in which the existence of a file is necessary
    // a good example of the inheritance paradigm
    [Binding]
    public class GetFileMetaSteps : FileTestBase
    {
        [When(@"I try to get '(.*)' file metadata")]
        public void WhenITryToGetFileMetadata(string filename)
        {
            GetFile(filename).UploadFile().CheckFileInfo();
            var response = new DropboxApi().GetFileMetadata(filename);
            response.EnsureSuccessful();
            ContextHelper.AddToContext("LastApiResponse", response);
        }

        [Then(@"I should get valid metadata")]
        public void ThenIShouldGetValidMetadata(FileResponseDto validData)
        {
            var apiResponse = ContextHelper.GetFromContext<ApiResponse>("LastApiResponse");
            var actualData = apiResponse.Content<FileMetaResponseDto>();

            actualData.Should().NotBeNull();
            actualData.Name.ShouldBeEquivalentTo(validData.Name);
        }
    }
}
