using NUnit.Framework;
using System;
using TechTalk.SpecFlow;
using TestDropboxApi.ApiFacade;
using TestDropboxApi.DataModels;
using TestDropboxApi.Helpers;

namespace Dropbox.Api.Tests.StepDefinitions
{
    [Binding]
    public class DeleteFileSteps
    {
        [When(@"I try delete '(.*)' file")]
        public void WhenITryDeleteFile(string fileName)
        {
            var response = new DropboxApi().DeleteFile("/" + fileName);
            response.EnsureSuccessful();
        }

        [Then(@"I should get no file info about '(.*)'")]
        public void ThenIShouldGetNoFileInfoAbout(string fileName)
        {
            var responseData = new DropboxApi().GetMetadata("/"+ fileName);
            Assert.Throws<Exception>(() => responseData.EnsureSuccessful());
        }


    }
}
