using System;
using System.IO;
using System.Reflection;
using FluentAssertions;
using TechTalk.SpecFlow;
using TestDropboxApi.ApiFacade;
using TestDropboxApi.DataModels;
using TestDropboxApi.Extensions;
using TestDropboxApi.Helpers;

namespace Dropbox.Api.Test.StepDefinitions
{
    [Binding]
    public class GetFileMetadataSteps
    {
        [When(@"I try to get file's metadata that is stored in my dropbox")]
        public void WhenITryToGetFileSMetadataThatIsStoredInMyDropbox(Base path)
        {
            var response = new DropboxApi().GetFileMetadata(path);
            response.EnsureSuccessful();
            ContextHelper.AddToContext("LastApiResponse", response);
        }
        
        [Then(@"I should be able to get the valid info")]
        public void ThenIShouldBeAbleToGetTheValidInfo(FileResponseDto fileInfo)
        {
            var apiResponse = ContextHelper.GetFromContext<ApiResponse>("LastApiResponse");
            var actualFileInfo = apiResponse.Content<FileResponseDto>();

            actualFileInfo.ShouldBeEquivalentTo(fileInfo, options => options.Including(f => f.Name));
        }
    }
}
