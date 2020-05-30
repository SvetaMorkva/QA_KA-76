using FluentAssertions;
using NUnit.Framework;
using System;
using System.Collections.Generic;
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
}
