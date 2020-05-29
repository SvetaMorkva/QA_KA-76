using FluentAssertions;
using FluentAssertions.Execution;
using NUnit.Framework;
using WebApiTesting.ApiFacade;
using WebApiTesting.DataModels;
namespace WebApiTesting
{
    [TestFixture]
    class ApiTests
    {

        [Test]
        public void TestGetAllFiles()
        {
            var response = new DropboxApi().GetFilesList();
            response.EnsureSuccessful();

            var listOfFiles = response.Content<FileListResponseDto>();

            using (new AssertionScope())
            {
                listOfFiles.Entries.Should().NotBeNullOrEmpty();
                listOfFiles.Entries[0].Should().Equals("Начало работы с Dropbox Paper.url");
            }
        }

        [Test]
        public void TestGetFileMetadata()
        {
            // arrange
            var allFilesResponse = new DropboxApi().GetFilesList();
            allFilesResponse.EnsureSuccessful();
            string testFileId = allFilesResponse.Content<FileListResponseDto>().Entries[0].Id;
            string testFileName = allFilesResponse.Content<FileListResponseDto>().Entries[0].Name;

            // act
            var fileMetadataResponse = new DropboxApi().GetFileMetadata(testFileId);
            fileMetadataResponse.EnsureSuccessful();

            // assert
            Assert.AreEqual(testFileName, fileMetadataResponse.Content<FileResponseDto>().Name);

        }

        [Test]
        public void TestDeleteFile()
        {
            // arrange
            var allFilesResponseBefore = new DropboxApi().GetFilesList();
            allFilesResponseBefore.EnsureSuccessful();
            var listOfFilesBefore = allFilesResponseBefore.Content<FileListResponseDto>();

            // act
            var response = new DropboxApi().DeleteFile("/9.jpg");
            response.EnsureSuccessful();

            // assert
            var allFilesResponseAfter = new DropboxApi().GetFilesList();
            allFilesResponseAfter.EnsureSuccessful();
            var listOfFilesAfter = allFilesResponseAfter.Content<FileListResponseDto>();

            Assert.AreEqual(1, listOfFilesBefore.Entries.ToArray().Length - listOfFilesAfter.Entries.ToArray().Length);
        }

    }
}
