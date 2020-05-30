using FluentAssertions;
using FluentAssertions.Execution;
using TechTalk.SpecFlow;
using TestDropboxApi.ApiFacade;
using TestDropboxApi.DataModels;
using TestDropboxApi.Helpers;

namespace Dropbox.Api.Tests.StepDefinitions
{
    [Binding]
    public class DeleteFolderSteps
    {
        [When(@"I try to delete folder '(.*)'")]
        public void WhenITryToDeleteFolder(string folderName)
        {
            var response = new DropboxApi().DeleteItem(new Base($"/{folderName}"));
            response.EnsureSuccessful();
            ContextHelper.AddToContext("LastApiResponse", response);
        }
        
        [Then(@"folder '(.*)' should not be in list of existing items")]
        public void ThenFolderShouldNotBeInListOfExistingItems(string folderName)
        {
            var response = new DropboxApi().GetFilesList();
            response.EnsureSuccessful();
            var actualItemList = response.Content<FileListResponseDto>();

            using (new AssertionScope())
            {
                foreach (var ItemInfo in actualItemList.Entries)
                    ItemInfo.Name.Should().NotBe(folderName);
            }
        }
    }
}
