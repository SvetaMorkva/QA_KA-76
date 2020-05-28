using FluentAssertions;
using System;
using TechTalk.SpecFlow;
using TestDropboxApi.ApiFacade;
using TestDropboxApi.DataModels;
using TestDropboxApi.Helpers;

namespace Dropbox.Api.Test.StepDefinitions
{
    [Binding]
    public class DeleteFolderSteps
    {
        [When(@"I try to delete a folder")]
        public void WhenITryToDeleteAFolder(Base path)
        {
            var response = new DropboxApi().DeleteFolder(path);
            response.EnsureSuccessful();
            ContextHelper.AddToContext("LastApiResponse", response);
        }
        
        [Then(@"I should be able to see the valid delete result")]
        public void ThenIShouldBeAbleToSeeTheValidDeleteResult(FolderResponseDto folderInfo)
        {
            var apiResponse = ContextHelper.GetFromContext<ApiResponse>("LastApiResponse");
            var actualFolderInfo = apiResponse.Content<FolderResponseDto>();

            actualFolderInfo.ShouldBeEquivalentTo(folderInfo, options => options.Including(f => f.metadata.Name));
        }
    }
}
