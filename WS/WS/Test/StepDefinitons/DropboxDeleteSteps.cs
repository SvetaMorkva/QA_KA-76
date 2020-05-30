using TechTalk.SpecFlow;
using TestDropboxApi.ApiFacade;
using TestDropboxApi.DataModels;
using TestDropboxApi.Helpers;

namespace Test.StepDefinitons
{
    [Binding]
    public class DropboxDeleteSteps
    {
        [When(@"I delete the file")]
        public void WhenIDeleteTheFile()
        {
            var file = ContextHelper.GetFromContext<FileResponseDto>("File");
            var response = new DropboxApi().GetFileMetadata(file.PathDisplay);
            ContextHelper.AddToContext("Metadata", response);
        }
    }
}
