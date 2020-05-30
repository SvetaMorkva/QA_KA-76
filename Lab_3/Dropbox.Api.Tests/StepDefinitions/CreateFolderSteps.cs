using Aropbox.Api.Tests.Infrastructure.DataModels;
using FluentAssertions;
using FluentAssertions.Execution;
using TechTalk.SpecFlow;
using TestDropboxApi.ApiFacade;
using TestDropboxApi.Helpers;

namespace Dropbox.Api.Tests.StepDefinitions
{
    [Binding]
    public class CreateFolderSteps
    {
        [When(@"I try to create folder")]
        public void WhenITryToCreateFolder(CreateFolderDto createFolder)
        {
            var response = new DropboxApi().CreateFolder(createFolder);
            response.EnsureSuccessful();
            ContextHelper.AddToContext("LastApiResponse", response);
        }
        
        [Then(@"I should be able to get folder '(.*)' info")]
        public void ThenIShouldBeAbleToGetFolderInfo(string folderName)
        {
            var apiResponse = ContextHelper.GetFromContext<ApiResponse>("LastApiResponse");
            var actualFolderInfo = apiResponse.Content<DeleteFileResponseDto>().Metadata;

            using (new AssertionScope())
            {
                actualFolderInfo.Should().NotBeNull();
                actualFolderInfo.Name.Should().Contain(folderName);
            }
        }
    }
}
