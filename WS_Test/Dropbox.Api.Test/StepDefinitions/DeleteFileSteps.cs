using Dropbox.Api.Test.Infrastructure.Commands;
using Dropbox.Api.Test.Infrastructure.ResponseModels;
using NUnit.Framework;
using System;
using TechTalk.SpecFlow;
using TestDropboxApi.ApiFacade;
using TestDropboxApi.Helpers;

namespace Dropbox.Api.Test.StepDefinitions
{
    [Binding]
    public class DeleteFileSteps
    {
        [When(@"I perform a delete")]
        public void WhenIPerformADelete(DeleteRequest request)
        {
            var response = new ApiResponse(request);
            ContextHelper.AddToContext("LastApiResponse", response);
            ContextHelper.AddToContext("DeleteRequest", request);
        }


        [Then(@"I should be able to see the valid delete result")]
        public void ThenIShouldBeAbleToSeeTheValidDeleteResult()
        {
            var response = ContextHelper.GetFromContext<ApiResponse>("LastApiResponse");
            var request = ContextHelper.GetFromContext<DeleteRequest>("DeleteRequest");

            var deleteResult = response.Content<DeleteResultDto>();

            Assert.AreEqual(request.Path, deleteResult.Metadata.PathDisplay);
        }
    }
}
