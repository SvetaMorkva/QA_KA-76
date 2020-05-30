using System;
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
            ApiResponse responseData = new DropboxApi().GetFileMetadata("/data.pdf");
            responseData.EnsureSuccessful();

            //assert
            Assert.AreEqual(testFileName, responseData.Content<FileResponseDto>().Name);
        }

        [Test]
        public void Test_DeleteFile_ShouldThrowException()
        {
            //act
            var responseDelete = new DropboxApi().DeleteFile("/data.pdf");
            responseDelete.EnsureSuccessful();
            var responseData = new DropboxApi().GetFileMetadata("/data.pdf");

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
            var uploadFile = new UploadFileDto
            {
                Path = "/" + filename,
                Mode = "add",
                AutoRename = true,
                Mute = false
            };
            var file = File.ReadAllBytes(datafile);
            var response = new DropboxApiContent().UploadFile(uploadFile, file);
            response.EnsureSuccessful();
        }

        private string GetFilePath(string fileName)
        {
            string codeBase = Path.GetDirectoryName(Assembly.GetExecutingAssembly().CodeBase) + Path.DirectorySeparatorChar 
                + ConfigurationHelper.DefaultFilePath;
            var uri = new UriBuilder(codeBase).Uri.Append(fileName);
            string fullPath = Path.GetFullPath(Uri.UnescapeDataString(uri.AbsolutePath));
            return fullPath;
        }
    }
}
