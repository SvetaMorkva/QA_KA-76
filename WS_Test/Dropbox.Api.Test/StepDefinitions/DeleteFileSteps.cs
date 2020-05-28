using NUnit.Framework;
using System;
using TechTalk.SpecFlow;
using TestDropboxApi.ApiFacade;
using TestDropboxApi.DataModels;
using TestDropboxApi.Helpers;

namespace Dropbox.Api.Test.StepDefinitions
{
    [Binding]
    public class DeleteFileSteps
    {
        [When(@"I delete this file")]
        public void WhenIDeleteThisFile()
        {
            var path = ContextHelper.GetFromContext<Base>("UploadedFilePath");

            var response = new DropboxApi().Delete(path);
            response.EnsureSuccessful();
            ContextHelper.AddToContext("LastApiResponse", response);
        }
    }
}
