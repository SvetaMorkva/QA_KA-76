using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using TechTalk.SpecFlow;
using TestDropboxApi.ApiFacade;
using TestDropboxApi.DataModels;
using TestDropboxApi.Extensions;
using TestDropboxApi.Helpers;

namespace Dropbox.Api.Test
{
    public class OriginalTestFilePaths
    {
        public const string originalPdfName = "MyPdf.pdf";

        public virtual string GetFullPath()
        {
            return GetFilePath(originalPdfName);
        }

        private string GetFilePath(string fileName) // Abstraction
        {
            string codeBase = Path.GetDirectoryName(Assembly.GetExecutingAssembly().CodeBase)
                              + Path.DirectorySeparatorChar
                              + ConfigurationHelper.DefaultFilePath;
            var uri = new UriBuilder(codeBase).Uri.Append(fileName);
            string fullPath = Path.GetFullPath(Uri.UnescapeDataString(uri.AbsolutePath));

            ScenarioContext.Current["DefaultFilePath"] = fullPath;
            return fullPath;
        }
    }

    public class NewTestFilePaths: OriginalTestFilePaths // Inheritance
    {
        public string newFileName { get; set; }
        public NewTestFilePaths(string filename)
        {
            newFileName = filename;
        }

        public override string GetFullPath() // Polymorphism
        {
            string originalPdfPath = base.GetFullPath();
            string originalPathOnly = originalPdfPath.Substring(0, originalPdfPath.Length - originalPdfName.Length);
            return originalPathOnly + newFileName;
        }
    }


    public class AllFilenames: DropboxApi // Inheritance
    {
        public static List<FileResponseDto> allDropboxFiles => getAllDropboxFileNames();
        private static List<FileResponseDto> getAllDropboxFileNames()
        {
            var response = new DropboxApi().GetFilesList();
            response.EnsureSuccessful();
            ContextHelper.AddToContext("LastApiResponse", response);

            return response.Content<FileListResponseDto>().Entries;
        }

    }
}
