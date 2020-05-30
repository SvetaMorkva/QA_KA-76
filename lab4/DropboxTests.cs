using System;
using Xunit;
using System.Threading.Tasks;
using Dropbox.Api;
using Dropbox.Api.Files;
using System.IO;
using System.Text;

namespace lab4
{
    public class DropboxTests
    {

        // string token = "sl.AbCUK3mFYsHEWl_ax-KAgIQvQ71k1A8_sp96zAFqRmxdGEgSuLVAv96BKLsXcP-HFfuRBim-bEpgx-NwO_OJHY4nM_yyy9n2jphjbW8ojYMvZi9y2TNNehsyvEktNwSalXqeweBH";

        [Fact]
        static async Task AuthenticationTest()
        {
            // Given
            string token = "sl.AbCUK3mFYsHEWl_ax-KAgIQvQ71k1A8_sp96zAFqRmxdGEgSuLVAv96BKLsXcP-HFfuRBim-bEpgx-NwO_OJHY4nM_yyy9n2jphjbW8ojYMvZi9y2TNNehsyvEktNwSalXqeweBH";
            var dbx = new DropboxClient(token);
            string fullName;
            string email;
            // When
            using (dbx)
            {
                var full = await dbx.Users.GetCurrentAccountAsync();
                fullName = full.Name.DisplayName;
                email = full.Email;
            }
            // Then
            Assert.Equal("Павел Пивовар", fullName);
            Assert.Equal("jalovanfres@gmail.com", email);
        }

        [Fact]
        async Task UploadTest()
        {
            //Given
            string token = "sl.AbCUK3mFYsHEWl_ax-KAgIQvQ71k1A8_sp96zAFqRmxdGEgSuLVAv96BKLsXcP-HFfuRBim-bEpgx-NwO_OJHY4nM_yyy9n2jphjbW8ojYMvZi9y2TNNehsyvEktNwSalXqeweBH";
            var dbx = new DropboxClient(token);
            string file = "myName.txt";
            string content = "Pavlo Pyvovar";
            //When
            using (var mem = new MemoryStream(Encoding.UTF8.GetBytes(content)))
            {
                var updated = await dbx.Files.UploadAsync(
                    $"/{file}",
                    WriteMode.Overwrite.Instance,
                    body: mem);
            }
            //Then
            // Assert.Equal(SearchMode.Filename());   
        }

        [Fact]
        public void TestGetFileMetaData()
        {
            //Given
            string token = "sl.AbCUK3mFYsHEWl_ax-KAgIQvQ71k1A8_sp96zAFqRmxdGEgSuLVAv96BKLsXcP-HFfuRBim-bEpgx-NwO_OJHY4nM_yyy9n2jphjbW8ojYMvZi9y2TNNehsyvEktNwSalXqeweBH";
            var dbx = new DropboxClient(token);
            string path = "/myName.txt";
            //When
            var fileMetaData = new GetMetadataArg(path, true, true, true);
            Console.WriteLine(fileMetaData);
            //Then
        }

        [Fact]
        async Task DeleteFileTest()
        {
            //Given
            string token = "sl.AbCUK3mFYsHEWl_ax-KAgIQvQ71k1A8_sp96zAFqRmxdGEgSuLVAv96BKLsXcP-HFfuRBim-bEpgx-NwO_OJHY4nM_yyy9n2jphjbW8ojYMvZi9y2TNNehsyvEktNwSalXqeweBH";
            var dbx = new DropboxClient(token);
            string FileName = "data.txt";
            // string content;
            var response = await dbx.Files.DeleteV2Async($"/{FileName}");
            //When
            // using (var response = await dbx.Files.DeleteV2Async(FileName))
            // {
            //     content = await response.GetContentAsStringAsync();
            // }      
            //Then
            // Console.WriteLine(content);
        }

        [Fact]
        static async Task DownloadFile()
        {
            //Given
            string token = "sl.AbCUK3mFYsHEWl_ax-KAgIQvQ71k1A8_sp96zAFqRmxdGEgSuLVAv96BKLsXcP-HFfuRBim-bEpgx-NwO_OJHY4nM_yyy9n2jphjbW8ojYMvZi9y2TNNehsyvEktNwSalXqeweBH";
            var dbx = new DropboxClient(token);
            string content;
            //When
            using (var response = await dbx.Files.DownloadAsync("/data.txt"))
            {
                content = await response.GetContentAsStringAsync();
            }            
            //Then
            Assert.Equal("Bla bla bla", content);
        }
    }
}
