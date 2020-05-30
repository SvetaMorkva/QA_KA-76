using System;
using System.IO;
using System.Reflection;
using Dropbox.Api.Test.Infrastructure.Commands;
using FluentAssertions;
using NUnit.Framework;
using TechTalk.SpecFlow;
using TestDropboxApi.ApiFacade;
using TestDropboxApi.Extensions;
using TestDropboxApi.Helpers;

namespace Dropbox.Api.Test.StepDefinitions
{
    [Binding]
    public class GetFolderAfterDeleteSteps
    {      
        [Then(@"I should receive an error")]
        public void ThenIShouldReceiveAnError()
        {
            var response = ContextHelper.GetFromContext<ApiResponse>("LastApiResponse");

            Assert.Throws<Exception>(() => response.EnsureSuccessful());
        }
    }
}
