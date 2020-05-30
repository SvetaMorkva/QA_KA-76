using NUnit.Framework;
using System;
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
        private string defaultFilename = "MyPdf.pdf";

        [Given(@"I have nonempty dropbox folder")]
        public void GivenIHaveAtLeastFileInMyDropboxTestFolder()
        {
            getAllDropboxFileNames();
            var apiResponse = ContextHelper.GetFromContext<ApiResponse>("LastApiResponse");
            var filesList = apiResponse.Content<FileListResponseDto>();

            if (filesList.Entries.Count == 0){
                UploadFileDto uploadFile = new UploadFileDto
                {
                    Path = "/"+ defaultFilename,
                    Mode = "add",
                    Mute = false
                };

                var file = File.ReadAllBytes(GetFileMetadataSteps.GetFilePath(defaultFilename));
                var response = new DropboxApiContent().UploadFile(uploadFile, file);
                response.EnsureSuccessful();

                getAllDropboxFileNames();
            }
        }
        
        [Then(@"I shoud be able to delete a file")]
        public void ThenIShoudBeAbleToDeleteAFile()
        {
            var apiResponse = ContextHelper.GetFromContext<ApiResponse>("LastApiResponse");
            var filesList = apiResponse.Content<FileListResponseDto>().Entries;
            var fileToDelName = filesList[0].Name;

            var response = new DropboxApi().DeleteFile(fileToDelName);
            response.EnsureSuccessful();
            ContextHelper.AddToContext("LastApiResponse", response);

            getAllDropboxFileNames();
            var filesListNew = ContextHelper.GetFromContext<ApiResponse>("LastApiResponse")
                                .Content<FileListResponseDto>().Entries;

            Assert.IsFalse(filesListNew.Contains(filesList[0]));
        }

        private void getAllDropboxFileNames()
        {
            var response = new DropboxApi().GetFilesList();
            response.EnsureSuccessful();
            ContextHelper.AddToContext("LastApiResponse", response);
        }
    }
}
