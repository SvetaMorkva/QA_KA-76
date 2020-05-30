using FluentAssertions;
using FluentAssertions.Execution;
using System;
using TechTalk.SpecFlow;
using TestDropboxApi.ApiFacade;
using TestDropboxApi.DataModels;
using TestDropboxApi.Helpers;

namespace Dropbox.Api.Tests.StepDefinitions
{
    [Binding]
    public class GetFileMetadataSteps
    {
        [When(@"I want to get file '(.*)' metadata")]
        public void WhenIWantToGetFileMetadata(string fileName)
        {
            var response = new DropboxApi().GetFileMetadata(fileName);
            response.EnsureSuccessful();
            ContextHelper.AddToContext("LastApiResponse", response);
        }
        
        [Then(@"I should be given valid file '(.*)' metadata")]
        public void ThenIShouldBeGivenValidFileMetadata(string fileName)
        {
            var apiResponse = ContextHelper.GetFromContext<ApiResponse>("LastApiResponse");
            var fileMetadata = apiResponse.Content<FileMetadataResponseDto>();
            using (new AssertionScope())
            {
                fileMetadata.Should().NotBeNull();
                fileMetadata.Name.Should().Be(fileName);
            }
        }
    }
}
