using Dropbox.Api.Test.Infrastructure.Commands;
using Dropbox.Api.Test.Infrastructure.ResponseModels;
using FluentAssertions;
using System;
using TechTalk.SpecFlow;
using TestDropboxApi.ApiFacade;
using TestDropboxApi.Helpers;

namespace Dropbox.Api.Test.StepDefinitions
{
    [Binding]
    public class GetListOfFilesSteps
    {
        [When(@"I try to get the list of all existing files in a folder")]
        public void WhenITryToGetTheListOfAllExistingFilesInAFolder(ListFolderRequest request)
        {
            var response = new ApiResponse(request);
            ContextHelper.AddToContext("LastApiResponse", response);
        }
        
        [Then(@"I should get a valid list of files")]
        public void ThenIShouldGetAValidListOfFiles()
        {
            var response = ContextHelper.GetFromContext<ApiResponse>("LastApiResponse");
            var filesList = response.Content<ListFolderResultDto>();
            filesList.Should().NotBeNull();
            filesList.Entries.Should().NotBeNullOrEmpty();
        }
    }
}
