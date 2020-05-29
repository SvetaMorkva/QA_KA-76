using System;
using NUnit.Framework;
using WebApi.ApiFacade;
using WebApi.DataModels;

namespace WebApi
{
    [TestFixture]
    public class WebApiTests
    {
        [Test]
        public void TestAFileMetadata()
        {
            // get file metadata
            string testFileName = "data.pdf";
            var responseData = new DropboxApi().GetFileMetadata("/data.pdf");
            responseData.EnsureSuccessful();
            Assert.AreEqual(testFileName, responseData.Content<FileResponseDto>().Name);
        }

        [Test]
        public void TestDeleteFile()
        {
            //delete file
            var responseDelete = new DropboxApi().DeleteFile("/data.pdf");
            responseDelete.EnsureSuccessful();

            var responseData = new DropboxApi().GetFileMetadata("/data.pdf");
            Assert.Throws<Exception>(() => responseData.EnsureSuccessful());
        }
    }
}
