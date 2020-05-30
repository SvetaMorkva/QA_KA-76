using System;
using Xunit;
using Dropbox.Api;
using System.Threading.Tasks;

public class UploadTest
{
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
}
