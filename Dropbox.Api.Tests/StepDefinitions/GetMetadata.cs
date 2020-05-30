using FluentAssertions;
using NUnit.Framework;
using System;
using TechTalk.SpecFlow;
using TestDropboxApi.ApiFacade;
using TestDropboxApi.DataModels;
using TestDropboxApi.Helpers;

namespace Dropbox.Api.Tests.StepDefinitions
{
    [Binding]
    public class GetMetadata
    {
        string fileName = "MyFile.pdf";
        [When(@"I try get file`s metatada")]
        public void WhenITryGetFileSMetatada()
        {
            var response = new DropboxApi().GetMetadata("/"+ fileName);
            response.EnsureSuccessful();
            ContextHelper.AddToContext("MetadataResponse", response);
        }

        [Then(@"I should get valid metadata")]
        public void ThenIShouldGetValidMetadata()
        {
            var apiResponse = ContextHelper.GetFromContext<ApiResponse>("MetadataResponse");
            var fileMeta = apiResponse.Content<FileResponseDto>();

            Assert.AreEqual(fileName, fileMeta.Name);
        }
    }
}
