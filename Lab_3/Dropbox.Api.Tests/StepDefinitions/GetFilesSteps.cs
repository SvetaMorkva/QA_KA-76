using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentAssertions;
using TechTalk.SpecFlow;
using TestDropboxApi.ApiFacade;
using TestDropboxApi.DataModels;
using TestDropboxApi.Helpers;

namespace Dropbox.Api.Tests.StepDefinitions
{
    [Binding]
    public sealed class GetFilesSteps
    {
        [When(@"I try to get list of all existing files")]
        public void WhenITryToGetListOfAllExistingFiles()
        {
            var response = new DropboxApi().GetFilesList();
            response.EnsureSuccessful();
            ContextHelper.AddToContext("LastApiResponse", response);
        }

        [Then(@"I should get valid list of files")]
        public void ThenIShouldGetValidListOfFiles()
        {
            var apiResponse = ContextHelper.GetFromContext<ApiResponse>("LastApiResponse");
            var filesList = apiResponse.Content<FileListResponseDto>();
            filesList.Should().NotBeNull();
            filesList.Entries.Should().NotBeNullOrEmpty();
        }

    }
}
