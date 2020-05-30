using NUnit.Framework;
using System.IO;
using TechTalk.SpecFlow;
using TestDropboxApi.ApiFacade;
using TestDropboxApi.DataModels;
using TestDropboxApi.Helpers;

namespace Dropbox.Api.Test.StepDefinitions
{
    [Binding]
    public class GetFileListSteps
    {
        [Given(@"I have nonempty dropbox folder")]
        public void GivenIHaveAtLeastFileInMyDropboxTestFolder()
        {
            if (AllFilenames.allDropboxFiles.Count == 0){
                UploadFileDto uploadFile = new UploadFileDto
                {
                    Path = "/" + OriginalTestFilePaths.originalPdfName,
                    Mode = "add",
                    Mute = false
                };

                OriginalTestFilePaths myPdfPaths = new OriginalTestFilePaths();
                var file = File.ReadAllBytes(myPdfPaths.GetFullPath());

                var response = new DropboxApiContent().UploadFile(uploadFile, file);
                response.EnsureSuccessful();
            }
        }
        
        [Then(@"I shoud be able to delete a file")]
        public void ThenIShoudBeAbleToDeleteAFile()
        {
            var filesList = AllFilenames.allDropboxFiles;
            var fileToDelName = filesList[0].Name;

            var response = new DropboxApi().DeleteFile(fileToDelName);
            response.EnsureSuccessful();
            ContextHelper.AddToContext("LastApiResponse", response);

            var filesListNew = AllFilenames.allDropboxFiles;

            Assert.IsFalse(filesListNew.Contains(filesList[0]));
        }
    }
}
