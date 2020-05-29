using WebApiTesting.Builders;
using WebApiTesting.Helpers;

namespace WebApiTesting.ApiFacade
{
    public class DropboxApiContent
    {
        public RequestBuilder request;
        public DropboxApiContent()
        {
            request = new RequestBuilder(ConfigurationHelper.ContentServiceUrl);
        }
    }
}
