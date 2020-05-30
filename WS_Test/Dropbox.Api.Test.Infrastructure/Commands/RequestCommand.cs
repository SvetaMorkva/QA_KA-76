using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TestDropboxApi.ApiFacade;
using TestDropboxApi.Builders;
using TestDropboxApi.Helpers;

namespace Dropbox.Api.Test.Infrastructure.Commands
{
    public abstract class RequestCommand
    {
        protected RequestBuilder RequestBuilder;

        public abstract HttpResponseMessage Execute();
    }
}
