// using System;
// using System.Threading.Tasks;
// using Dropbox.Api;

// class Program
// {
//     static void Main(string [] args)
//     {
//         var task = Task.Run((Func<Task>)Program.Run);
//         task.Wait();
//     }

//     static async Task Run()
//     {
//         using (var dbx = new DropboxClient("sl.AbCCFDX9WV_LGcaHzJjd2E1DCrlPBGouua0kb4uoM91kq1Exp1-CtK-zz8jW4qV53Q9ttfHhpPyAELBcU_F2DrLCFJ7AkDbyDoGbCK0lVqOVsPMri-rkMFQEg_TkZEkweariDFma"))
//         {
//             var full = await dbx.Users.GetCurrentAccountAsync();
//             Console.WriteLine("{0} - {1}", full.Name.DisplayName, full.Email);
//         }
//     }
// }