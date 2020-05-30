using FluentAssertions;
using NUnit.Framework;
using System;
using System.IO;
using System.Reflection;
using TechTalk.SpecFlow;
using TestDropboxApi.ApiFacade;
using TestDropboxApi.DataModels;
using TestDropboxApi.Extensions;
using TestDropboxApi.Helpers;

namespace Dropbox.Api.Test.StepDefinitions
{
    [Binding]
    public class GetFileMetadataSteps
    {
        private readonly string newFileName = Path.GetRandomFileName().Replace(".", "") + ".pdf";
        private readonly string originalPdfName = "MyPdf.pdf";

        [When(@"I uploaded a file")]
        public void WhenIUploadedAFile(UploadFileDto uploadFile)
        {
            // rename old pdf file to get a "new" one
            string originalPdfPath = GetFilePath(originalPdfName);
            string newFilePath = originalPdfPath.Substring(0, originalPdfPath.Length-originalPdfName.Length) + newFileName;
            File.Copy(GetFilePath("MyPdf.pdf"), newFilePath);
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

        public static string GetFilePath(string fileName)
        {
            string codeBase = Path.GetDirectoryName(Assembly.GetExecutingAssembly().CodeBase)
                              + Path.DirectorySeparatorChar
                              + ConfigurationHelper.DefaultFilePath;
            var uri = new UriBuilder(codeBase).Uri.Append(fileName);
            string fullPath = Path.GetFullPath(Uri.UnescapeDataString(uri.AbsolutePath));

            ScenarioContext.Current["DefaultFilePath"] = fullPath;
            return fullPath;
        }
    }
}
