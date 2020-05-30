using NUnit.Framework;
using System.IO;
using TechTalk.SpecFlow;
using TestDropboxApi.ApiFacade;
using TestDropboxApi.DataModels;
using TestDropboxApi.Helpers;

namespace Dropbox.Api.Test.StepDefinitions
{
    [Binding]
    public class GetFileMetadataSteps
    {
        private readonly string newFileName = Path.GetRandomFileName().Replace(".", "") + ".pdf";

        [When(@"I uploaded a file")]
        public void WhenIUploadedAFile(UploadFileDto uploadFile)
        {
            // rename old pdf file to get a "new" one
            OriginalTestFilePaths myPdfPaths = new OriginalTestFilePaths();
            NewTestFilePaths newPdfPaths = new NewTestFilePaths(newFileName);
            string newFilePath = newPdfPaths.GetFullPath();

            File.Copy(myPdfPaths.GetFullPath(), newFilePath);
            ContextHelper.AddToContext("FilePath", newFilePath);

            //upload to dropbox
            uploadFile.Path = "/" + newFileName;
            var file = File.ReadAllBytes(newFilePath);
            var response = new DropboxApiContent().UploadFile(uploadFile, file);

            response.EnsureSuccessful();
            ContextHelper.AddToContext("LastApiResponse", response);
        }
         
        [Then(@"I shoud be able to get file metadata")]
        public void ThenIShoudBeAbleToGetFileMetadata()
        {
            var response = new DropboxApi().GetFileMetadata(newFileName);
            response.EnsureSuccessful();
            ContextHelper.AddToContext("LastApiResponse", response);

            var actualFileInfo = response.Content<FileResponseDto>();
            Assert.AreEqual(newFileName, actualFileInfo.Name);
        }
    }
}
