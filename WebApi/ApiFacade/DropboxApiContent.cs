﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using WebApi.Builders;
using WebApi.DataModels;
using WebApi.Helpers;

namespace WebApi.ApiFacade
{
    public class DropboxApiContent
    {
        public RequestBuilder request;
        public DropboxApiContent()
        {
            request = new RequestBuilder(ConfigurationHelper.ContentServiceUrl);
        }

        public ApiResponse UploadFile(UploadFileDto uploadDto, byte[] file)
        {
            var url = "files/upload";
            var requestBody = JsonConvert.SerializeObject(uploadDto);
            return request.Uri(url).Method(HttpMethod.Post).WithHeader("Dropbox-API-Arg", requestBody).WithFile(file).Execute();
        }
    }
}
