using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using WebApiTesting.Helpers;

namespace WebApiTesting.Extensions
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
