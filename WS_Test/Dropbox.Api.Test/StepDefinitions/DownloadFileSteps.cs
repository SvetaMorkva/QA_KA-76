using System;
using System.IO;
using System.Reflection;
using FluentAssertions;
using NUnit.Framework;
using TechTalk.SpecFlow;
using TestDropboxApi.ApiFacade;
using TestDropboxApi.DataModels;
using TestDropboxApi.Extensions;
using TestDropboxApi.Helpers;

namespace Dropbox.Api.Test.StepDefinitions
{
    [Binding]
    public class DownloadFileSteps
    {        
        [When(@"I try to download the same file from my dropbox")]
        public void WhenITryToDownloadTheSameFileFromMyDropbox(Base path)
        {
            var response = new DropboxApiContent().DownloadFile(path);
            response.EnsureSuccessful();
            ContextHelper.AddToContext("LastApiResponse", response);
        }
        
        [Then(@"these two files should be identical")]
        public void ThenTheseTwoFilesShouldBeIdentical()
        {
            var filePath = ContextHelper.GetFromContext<string>("FilePath");
            var apiResponse = ContextHelper.GetFromContext<ApiResponse>("LastApiResponse");

            FileInfo localFile = new FileInfo(filePath);
            byte[] downloadedFile = apiResponse.ContentAsByteArray;

            bool areEqual = FilesAreEqual(localFile, downloadedFile);

            Assert.IsTrue(areEqual);
        }


        
        private bool FilesAreEqual(FileInfo first, byte[] second)
        {
            const int BYTES_TO_READ = sizeof(Int64);
            int iterations = (int)Math.Ceiling((double)first.Length / BYTES_TO_READ);

            using (FileStream fs1 = first.OpenRead())
            {
                byte[] one = new byte[BYTES_TO_READ];
                byte[] two = new byte[BYTES_TO_READ];

                int offset = 0;

                for (int i = 0; i < iterations; i++)
                {
                    fs1.Read(one, 0, BYTES_TO_READ);

                    for (int k = 0; k < BYTES_TO_READ; k++)
                    {
                        if (offset < second.Length)
                            two[k] = second[offset];

                        offset++;
                    }

                    /*
                    for (int j = 0; j < one.Length; j++)
                    {
                        Console.Write(one[j]);
                    }
                    Console.WriteLine("");
                    for (int j = 0; j < one.Length; j++)
                    {
                        Console.Write(two[j]);
                    }
                    Console.WriteLine("");
                    */

                    if (BitConverter.ToInt64(one, 0) != BitConverter.ToInt64(two, 0))
                        return false;
                }
            }
            return true;
        }

    }
}
