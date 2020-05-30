using System;
using System.IO;
using System.Reflection;
using Dropbox.Api.Test.Infrastructure.Commands;
using Dropbox.Api.Test.Infrastructure.ResponseModels;
using FluentAssertions;
using NUnit.Framework;
using TechTalk.SpecFlow;
using TestDropboxApi.ApiFacade;
using TestDropboxApi.Extensions;
using TestDropboxApi.Helpers;

namespace Dropbox.Api.Test.StepDefinitions
{
    [Binding]
    public class GetFileMetadataSteps
    {
        [When(@"I try to get metadata")]
        public void WhenITryToGetMetadata(GetMetadataRequest request)
        {
            var response = new ApiResponse(request);
            ContextHelper.AddToContext("LastApiResponse", response);
            ContextHelper.AddToContext("GetMetadataRequest", request);
        }


        [Then(@"I should be able to get the valid get metadata info")]
        public void ThenIShouldBeAbleToGetTheValidGetMetadataInfo()
        {
            var response = ContextHelper.GetFromContext<ApiResponse>("LastApiResponse");
            var request = ContextHelper.GetFromContext<GetMetadataRequest>("GetMetadataRequest");

            response.EnsureSuccessful();
            var metadataInfo = response.Content<MetadataDto>();

            Assert.AreEqual(request.Path, metadataInfo.PathDisplay);
        }
    }
}
