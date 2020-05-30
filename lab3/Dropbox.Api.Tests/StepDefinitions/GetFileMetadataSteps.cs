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
        private readonly string originalPdfName = MyPdfTestFilePaths.originalPdfName;

        [When(@"I uploaded a file")]
        public void WhenIUploadedAFile(UploadFileDto uploadFile)
        {
            // rename old pdf file to get a "new" one
            MyPdfTestFilePaths myPdfPaths = new MyPdfTestFilePaths();
            string originalPdfPath = myPdfPaths.GetFullPath();
            string newFilePath = originalPdfPath.Substring(0, originalPdfPath.Length-originalPdfName.Length) + newFileName;
            File.Copy(originalPdfPath, newFilePath);
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
