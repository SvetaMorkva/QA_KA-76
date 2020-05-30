using System;
using System.IO;
using System.Linq;
using System.Reflection;
using TechTalk.SpecFlow;
using TestDropboxApi.Extensions;
using TestDropboxApi.Helpers;

namespace Dropbox.Api.Test
{
    public class MyPdfTestFilePaths
    {
        public const string originalPdfName = "MyPdf.pdf";

        public MyPdfTestFilePaths()
        {
        }

        public virtual string GetFullPath()
        {
            return GetFilePath(originalPdfName);
        }

        protected string GetFilePath(string fileName)
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
}
