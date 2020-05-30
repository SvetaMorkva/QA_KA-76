using NUnit.Framework;
using System.Collections.Generic;
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
            if (getAllDropboxFileNames().Count == 0){
                UploadFileDto uploadFile = new UploadFileDto
                {
                    Path = "/" + MyPdfTestFilePaths.originalPdfName,
                    Mode = "add",
                    Mute = false
                };

                MyPdfTestFilePaths myPdfPaths = new MyPdfTestFilePaths();
                var file = File.ReadAllBytes(myPdfPaths.GetFullPath());

                var response = new DropboxApiContent().UploadFile(uploadFile, file);
                response.EnsureSuccessful();
            }
        }
        
        [Then(@"I shoud be able to delete a file")]
        public void ThenIShoudBeAbleToDeleteAFile()
        {
            var filesList = getAllDropboxFileNames();
            var fileToDelName = filesList[0].Name;

            var response = new DropboxApi().DeleteFile(fileToDelName);
            response.EnsureSuccessful();
            ContextHelper.AddToContext("LastApiResponse", response);

            var filesListNew = getAllDropboxFileNames();

            Assert.IsFalse(filesListNew.Contains(filesList[0]));
        }

        private List<FileResponseDto> getAllDropboxFileNames()
        {
            var response = new DropboxApi().GetFilesList();
            response.EnsureSuccessful();
            ContextHelper.AddToContext("LastApiResponse", response);

            return response.Content<FileListResponseDto>().Entries;
        }
    }
}
