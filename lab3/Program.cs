using System;
using System.Threading.Tasks;
using Dropbox.Api;

namespace lab3
{
    class Program
    {
        static void Main(string[] args)
        {
            var task = Task.Run((Func<Task>)Program.Run);
            task.Wait();
        }

        static async Task Run()
        {
            using (var dbx = new DropboxClient("Z95pbDATY6AAAAAAAAAARrIjCGnovcmBtpAYQJnoul2B89pH6bngzRJ72suFyqjx"))
            {
                var full = await dbx.Users.GetCurrentAccountAsync();
                Console.WriteLine("{0} - {1}", full.Name.DisplayName, full.Email);
            }
        }

        // async Task ListRootFolder(DropboxClient dbx)
        // {
        //     var list = await dbx.Files.ListFolderAsync(string.Empty);

        //     // show folders then files
        //     foreach (var item in list.Entries.Where(i => i.IsFolder))
        //     {
        //         Console.WriteLine("D  {0}/", item.Name);
        //     }

        //     foreach (var item in list.Entries.Where(i => i.IsFile))
        //     {
        //         Console.WriteLine("F{0,8} {1}", item.AsFile.Size, item.Name);
        //     }
        // }

        // public void GivenIHaveFileToUpload(string fileName)
        // {
        //     var filePath = GetFilePath(fileName);
        //     File.Exists(filePath)
        //         .Should()
        //         .BeTrue($"expected {fileName} to exists with test fata files inside the {filePath}");
            
        //     ContextHelper.AddToContext("FilePath", filePath);
        // }

    }
}
