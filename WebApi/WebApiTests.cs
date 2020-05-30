using System;
using System.Configuration;
using System.IO;
using System.Reflection;
using NUnit.Framework;
using WebApi.ApiFacade;
using WebApi.DataModels;
using WebApi.Extensions;
using WebApi.Helpers;

namespace WebApi
{
    [TestFixture]
    public class WebApiTests
    {
        private DropboxApiService ApiService = new DropboxApiService();
        private DropboxApiContent ApiContent = new DropboxApiContent();
        [SetUp]
        public void SetUp()
        {
            string filename = "data.pdf";
            UploadFileToTest(filename);
        }


        [Test]
        public void Test_GetFileMetaData_ShouldEnsureFilenameIsEqual()
        {
            //arrange
            string testFileName = "data.pdf";

            //act
            ApiService.CreateRequest();
            ApiResponse responseData = ApiService.GetFileMetadata("/data.pdf");
            responseData.EnsureSuccessful();

            //assert
            Assert.AreEqual(testFileName, responseData.Content<FileResponseDto>().Name);
        }

        [Test]
        public void Test_DeleteFile_ShouldThrowException()
        {
            //act
            ApiService.CreateRequest();
            ApiResponse responseDelete = ApiService.DeleteFile("/data.pdf");
            responseDelete.EnsureSuccessful();

            ApiService.CreateRequest();
            ApiResponse responseData = ApiService.GetFileMetadata("/data.pdf");

            //assert
            Assert.Throws<Exception>(() => responseData.EnsureSuccessful());
        }

        private void UploadFileToTest(string filename)
        {
            string datafile = GetFilePath(filename);
            if (!File.Exists(datafile))
            {
                throw new FileNotFoundException("File " + datafile + " does not exists");
            }
            UploadFileDto uploadFile = new UploadFileDto
            {
                Path = "/" + filename,
                Mode = "add",
                AutoRename = true,
                Mute = false
            };
            byte[] file = File.ReadAllBytes(datafile);
            ApiContent.CreateRequest();
            ApiContent.UploadFile(uploadFile, file).EnsureSuccessful();
        }

        private string GetFilePath(string fileName)
        {
            string codeBase = Path.GetDirectoryName(Assembly.GetExecutingAssembly().CodeBase) + Path.DirectorySeparatorChar 
                + ConfigurationHelper.DefaultFilePath;
            Uri uri = new UriBuilder(codeBase).Uri.Append(fileName);
            string fullPath = Path.GetFullPath(Uri.UnescapeDataString(uri.AbsolutePath));
            return fullPath;
        }
    }
}
