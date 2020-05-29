using FluentAssertions;
using FluentAssertions.Execution;
using NUnit.Framework;
using TestDropboxApi.ApiFacade;
using TestDropboxApi.DataModels;

namespace Dropbox.Api.Test
{
    [TestFixture]
    class DropboxTest
    {
        [Test]
        public void GetFileMetadata()
        {
            var allFiles = new DropboxApi().GetFilesList();
            allFiles.EnsureSuccessful();
            string testFileName = allFiles.Content<FileListResponseDto>().Entries[2].Name;            
            string file_name = "титулка.docx";
            var response = new DropboxApi().FileMetadata(file_name);
            response.EnsureSuccessful();
          
            using (new AssertionScope())
            {
                testFileName.Should().NotBeNull();
                testFileName.Should().Be(file_name);
            }
        }

        [Test]
        public void DeleteTest()
        {
            var present_files = new DropboxApi().GetFilesList();
            present_files.EnsureSuccessful();
            var file_list = present_files.Content<FileListResponseDto>();

            var response = new DropboxApi().DeleteFile("/MyFile.pdf");
            response.EnsureSuccessful();

            var after_delete = new DropboxApi().GetFilesList();
            after_delete.EnsureSuccessful();
            var list_after_delete = after_delete.Content<FileListResponseDto>();

            Assert.AreEqual(1, file_list.Entries.ToArray().Length - list_after_delete.Entries.ToArray().Length);
        }

    }
}
