using System;
using System.Net.Http;
using System.Threading.Tasks;
using TestDropboxApi.ApiFacade;

namespace TestDropboxApi.Extensions
{
    public static class RequestExtensions
    {
        public static ApiResponse ReadResponse(this Task<HttpResponseMessage> responseTask, int timeoutMs = 100000)
        {
            if (responseTask.Wait(timeoutMs))
                return new ApiResponse(responseTask.Result);

            throw new TimeoutException($"Request timed out. Timout = {timeoutMs}ms");
        }
    }
}
