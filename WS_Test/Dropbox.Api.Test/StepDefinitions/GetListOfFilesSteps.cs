using FluentAssertions;
using System;
using TechTalk.SpecFlow;
using TestDropboxApi.ApiFacade;
using TestDropboxApi.DataModels;
using TestDropboxApi.Helpers;

namespace Dropbox.Api.Test.StepDefinitions
{
    [Binding]
    public class GetListOfFilesSteps
    {
        [When(@"I try to get the list of all existing files in a folder")]
        public void WhenITryToGetTheListOfAllExistingFilesInAFolder(Base path)
        {
            var response = new DropboxApi().GetFilesList(path);
            response.EnsureSuccessful();
            ContextHelper.AddToContext("LastApiResponse", response);
        }
        
        [Then(@"I should get a valid list of files")]
        public void ThenIShouldGetAValidListOfFiles()
        {
            var apiResponse = ContextHelper.GetFromContext<ApiResponse>("LastApiResponse");
            var filesList = apiResponse.Content<FileListResponseDto>();
            filesList.Should().NotBeNull();
            filesList.Entries.Should().NotBeNullOrEmpty();
        }
    }
}
