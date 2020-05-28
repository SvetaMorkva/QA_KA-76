using System;
using TechTalk.SpecFlow;
using FluentAssertions;
using TestDropboxApi.ApiFacade;
using TestDropboxApi.DataModels;
using TestDropboxApi.Extensions;
using TestDropboxApi.Helpers;
using Dropbox.Api.Test.Infrastructure.DataModels;
using NUnit.Framework;

namespace Dropbox.Api.Test.StepDefinitions
{
    [Binding]
    public class CreateFolderSteps
    {
        [When(@"I try to create a folder")]
        public void WhenITryToCreateAFolder(CreateFolderDto createFolderDto)
        {
            var response = new DropboxApi().CreateFolder(createFolderDto);
            response.EnsureSuccessful();

            var path = new Base();
            path.Path = createFolderDto.Path;
            ContextHelper.AddToContext("folderPath", path);
            
            ContextHelper.AddToContext("LastApiResponse", response);
        }

        [Then(@"I should be able to see folder info")]
        public void ThenIShouldBeAbleToSeeFolderInfo(FolderResponseDto folderInfo)
        {
            var apiResponse = ContextHelper.GetFromContext<ApiResponse>("LastApiResponse");
            var actualFolderInfo = apiResponse.Content<FolderResponseDto>();

            Assert.IsTrue(actualFolderInfo.Metadata.Name.Contains(folderInfo.Metadata.Name));
        }
    }
}
