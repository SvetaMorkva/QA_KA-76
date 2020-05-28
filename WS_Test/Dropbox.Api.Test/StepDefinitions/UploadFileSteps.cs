﻿using System;
using System.IO;
using System.Reflection;
using Dropbox.Api.Test.Infrastructure.DataModels;
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
    public class UploadFileSteps
    {
        [Given(@"I have '(.*)' file to upload")]
        public void GivenIHaveFileToUpload(string fileName)
        {
            var filePath = GetFilePath(fileName);
            File.Exists(filePath)
                .Should()
                .BeTrue($"expected {fileName} to exists with test fata files inside the {filePath}");

            ContextHelper.AddToContext("FilePath", filePath);
        }

        [Given(@"I also have folder in Dropbox")]
        public void GivenIAlsoHaveFolderInDropbox(Base path)
        {
            var response = new DropboxApi().GetFileMetadata(path);
            response.EnsureSuccessful();
            var folder = response.Content<Metadata>();
            string respath = folder.PathLower;

            Assert.AreEqual(path.Path, respath);
        }


        [When(@"I upload the file")]
        public void WhenIUploadTheFile(UploadFileDto uploadFile)
        {
            var filePath = ContextHelper.GetFromContext<string>("FilePath");
            var file = File.ReadAllBytes(filePath);
            var response = new DropboxApiContent().UploadFile(uploadFile, file);
            response.EnsureSuccessful();
            ContextHelper.AddToContext("LastApiResponse", response);

            var uploadPath = new Base();
            uploadPath.Path = uploadFile.Path;
            ContextHelper.AddToContext("UploadedFilePath", uploadPath);
        }

        [Then(@"I should be able to get file info")]
        public void ThenIShouldBeAbleToGetFileInfo(FileResponseDto fileInfo)
        {
            var apiResponse = ContextHelper.GetFromContext<ApiResponse>("LastApiResponse");
            var actualFileInfo = apiResponse.Content<FileResponseDto>();

            actualFileInfo.ShouldBeEquivalentTo(fileInfo, options => options.Including(f => f.Name));
        }

        private string GetFilePath(string fileName)
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
