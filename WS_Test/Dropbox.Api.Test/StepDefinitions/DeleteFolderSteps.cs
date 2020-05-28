using FluentAssertions;
using NUnit.Framework;
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
        [Then(@"I should be able to see the valid delete result")]
        public void ThenIShouldBeAbleToSeeTheValidDeleteResult(Base path)
        {
            var apiResponse = ContextHelper.GetFromContext<ApiResponse>("LastApiResponse");
            var actualFolderInfo = apiResponse.Content<FolderResponseDto>();
            Assert.AreEqual(path.Path, actualFolderInfo.Metadata.PathDisplay);
        }
    }
}
