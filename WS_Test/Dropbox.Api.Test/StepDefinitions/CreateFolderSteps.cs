using System;
using TechTalk.SpecFlow;
using FluentAssertions;
using TestDropboxApi.ApiFacade;
using TestDropboxApi.DataModels;
using TestDropboxApi.Extensions;
using TestDropboxApi.Helpers;

namespace Dropbox.Api.Test.StepDefinitions
{
    [Binding]
    public class CreateFolderSteps
    {
        [When(@"I try to create a folder")]
        public void WhenITryToCreateAFolder(CreateFolderDto createFolderDto)
        {
            var response = new DropboxApi().CreateFolder(createFolderDto);
            response.EnsureSuccessful();
            ContextHelper.AddToContext("LastApiResponse", response);
        }

        [Then(@"I should be able to see folder info")]
        public void ThenIShouldBeAbleToSeeFolderInfo(FolderResponseDto folderInfo)
        {
            var apiResponse = ContextHelper.GetFromContext<ApiResponse>("LastApiResponse");
            var actualFolderInfo = apiResponse.Content<FolderResponseDto>();
            
            actualFolderInfo.ShouldBeEquivalentTo(folderInfo, options => options.Including(f => f.metadata.Name));
        }
    }
}
