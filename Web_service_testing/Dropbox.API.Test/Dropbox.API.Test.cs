using FluentAssertions;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestDropboxApi.ApiFacade;
using TestDropboxApi.DataModels;
using TestDropboxApi.Helpers;

namespace Dropbox.API.Test
{
    class GetFileMetadataTest
    {
        [TestCase("/stickers/1.jpg")]
        [TestCase("/stickers/1-90.jpg")]
        [TestCase("/stickers/973.png")]

        public void GetFileMetadata(string file_path)
        {
            var response = new DropboxApi().GetFilesMetadata(file_path);
            response.EnsureSuccessful();

            var apiResponse = response.Content<FileResponseDto>();
            apiResponse.Should().NotBeNull();

            Assert.AreEqual(file_path, apiResponse.PathDisplay); 
        }
    }

    class DeleteFileTest
    {
        private static string filePath = "/GuiltyFile.txt";
        private static string local_file_path = Directory.GetCurrentDirectory() + filePath;

        [SetUp]
        public void Setup()
        {
            if (!File.Exists(local_file_path))
            {
                using (StreamWriter sw = File.CreateText(local_file_path))
                {
                    sw.WriteLine("DeleteFileTest");
                }
            }

            File.Exists(local_file_path)
                .Should();

            var file = File.ReadAllBytes(local_file_path);
            var uploadFile = new UploadFileDto();
            uploadFile.Path = filePath;
            uploadFile.Mode = "add";
            uploadFile.AutoRename = true;
            uploadFile.Mute = false;
            var response = new DropboxApiContent().UploadFile(uploadFile, file);
            response.EnsureSuccessful();
        }

        [Test]
        public void DeleteFile()
        {
            var response = new DropboxApi().DeleteFiles(filePath);
            response.EnsureSuccessful();

            var apiResponse = response.Content<FileResponseDto>();
            apiResponse.Should().NotBeNull();

            Assert.AreEqual(filePath, apiResponse.PathDisplay);
        }

        [TearDown]
        public void CleanUp()
        {
            if (File.Exists(local_file_path))
            {
                File.Delete(local_file_path);
            }
        }
    }
}
