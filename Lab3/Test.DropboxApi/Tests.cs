using FluentAssertions;
using FluentAssertions.Execution;
using NUnit.Framework;
using TestDropboxApi.ApiFacade;
using TestDropboxApi.DataModels;

namespace Dropbox.Api.Tests
{
    [TestFixture]
    class Tests
    {
        [Test]
        public void GetMetadata()
        {
 
            var filesResponse = new DropboxApi().GetFilesList();
            filesResponse.EnsureSuccessful();
            string fileName = filesResponse.Content<FileListResponseDto>().Entries[2].Name;

            string pictureName = "chb-kartinki-dlya-ld-raspechatki-117965.jpg";
            var pathFile = new Base();
            pathFile.Path = $"/{pictureName}";
            var metadataResponse = new DropboxApi().GetFileMetadata(pathFile);
            metadataResponse.EnsureSuccessful();

            Assert.AreEqual(fileName, metadataResponse.Content<FileResponseDto>().Name);

        }

        [Test]
        public void TestDeleteFile()
        {

            var filesResponseBefore = new DropboxApi().GetFilesList();
            filesResponseBefore.EnsureSuccessful();
            var listBefore = filesResponseBefore.Content<FileListResponseDto>();


            string MyFileName = "MyFile.pdf";
            var pathMyFile = new Base();
            pathMyFile.Path = $"/{MyFileName}";
            var response = new DropboxApi().DeleteFile(pathMyFile);
            response.EnsureSuccessful();


            var filesResponseAfter = new DropboxApi().GetFilesList();
            filesResponseAfter.EnsureSuccessful();
            var listAfter = filesResponseAfter.Content<FileListResponseDto>();

            Assert.AreEqual(1, listBefore.Entries.ToArray().Length - listAfter.Entries.ToArray().Length);
        }

    }
}
