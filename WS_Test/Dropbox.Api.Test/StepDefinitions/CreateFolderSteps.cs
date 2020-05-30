using System;
using TechTalk.SpecFlow;
using FluentAssertions;
using TestDropboxApi.ApiFacade;
using TestDropboxApi.Extensions;
using TestDropboxApi.Helpers;
using NUnit.Framework;
using Dropbox.Api.Test.Infrastructure.Commands;
using Dropbox.Api.Test.Infrastructure.Helpers;
using Dropbox.Api.Test.Infrastructure.ResponseModels;

namespace Dropbox.Api.Test.StepDefinitions
{
    [Binding]
    public class CreateFolderSteps
    {
        [When(@"I try to create a folder")]
        public void WhenITryToCreateAFolder(CreateFolderRequest request)
        {
            ApiResponse response = new ApiResponse(request);

            ContextHelper.AddToContext("CreateFolderRequest", request);
            ContextHelper.AddToContext("LastApiResponse", response);
        }


        [Then(@"I should be able to see the valid create folder info")]
        public void ThenIShouldBeAbleToSeeTheValidFolderInfo()
        {
            var response = ContextHelper.GetFromContext<ApiResponse>("LastApiResponse");
            var request = ContextHelper.GetFromContext<CreateFolderRequest>("CreateFolderRequest");

            var createFolderResultDto = response.Content<CreateFolderResultDto>();

            // Contains due to autorename feature
            Assert.IsTrue(createFolderResultDto.Metadata.PathDisplay.Contains(request.Path));
        }
    }
}
