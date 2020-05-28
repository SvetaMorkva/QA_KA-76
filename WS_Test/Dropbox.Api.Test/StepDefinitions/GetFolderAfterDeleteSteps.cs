using System;
using System.IO;
using System.Reflection;
using Dropbox.Api.Test.Infrastructure.DataModels;
using FluentAssertions;
using NUnit.Framework;
using TechTalk.SpecFlow;
using TestDropboxApi.ApiFacade;
using TestDropboxApi.DataModels;
using TestDropboxApi.Extensions;
using TestDropboxApi.Helpers;

namespace Dropbox.Api.Test.StepDefinitions
{
    [Binding]
    public class GetFolderAfterDeleteSteps
    {      

        [When(@"I delete this folder")]
        public void WhenIDeleteThisFolder()
        {
            var path = ContextHelper.GetFromContext<Base>("folderPath");

            var response = new DropboxApi().Delete(path);
            response.EnsureSuccessful();
            ContextHelper.AddToContext("LastApiResponse", response);
        }


        [When(@"I try to get metadata")]
        public void WhenITryToGetMetadata(Base path)
        {
            var response = new DropboxApi().GetFileMetadata(path);
            ContextHelper.AddToContext("LastApiResponse", response);
        }
        
        [Then(@"I should receive an error")]
        public void ThenIShouldReceiveAnError()
        {
            var response = ContextHelper.GetFromContext<ApiResponse>("LastApiResponse");

            Assert.Throws<Exception>(() => response.EnsureSuccessful());
        }
    }
}
