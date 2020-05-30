using NUnit.Framework;
using System;
using TechTalk.SpecFlow;
using TestDropboxApi.ApiFacade;
using TestDropboxApi.DataModels;
using TestDropboxApi.Helpers;

namespace Dropbox.Api.Tests.StepDefinitions
{
    [Binding]
    public class GetMetadataSteps
    {
        [When(@"I try get '(.*)' file`s metatada")]
        public void WhenITryGetFileSMetatada(string fileName)
        {
            var response = new DropboxApi().GetMetadata("/" + fileName);
            response.EnsureSuccessful();
            ContextHelper.AddToContext("MetadataResponse", response);
        }
        
        [Then(@"I should get valid file`s metadata")]
        public void ThenIShouldGetValidFileSMetadata(FileResponseDto fileInfo)
        {
            var apiResponse = ContextHelper.GetFromContext<ApiResponse>("MetadataResponse");
            var fileMeta = apiResponse.Content<FileResponseDto>();

            Assert.AreEqual(fileInfo.Name, fileMeta.Name);
        }
    }
}
