using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Net;
using System.Net.Http;

namespace WebApiTesting.Helpers
{
    public class Response
    {
        public HttpStatusCode StatusCode { get; }

        public Response(HttpResponseMessage responseMessage)
        {
            StatusCode = responseMessage.StatusCode;
        }
        public virtual void EnsureSuccessful()
        {
            if ((int)StatusCode < 200 || (int)StatusCode >= 300)
            {
                throw new Exception(
                    $"StatusCode is {StatusCode}");
            }
        }
    }


    public class ApiResponse : Response
    {
        public string ContentAsString { get; set; }

        public ApiResponse(HttpResponseMessage responseMessage) : base(responseMessage)
        {
            ContentAsString = responseMessage.Content.ReadAsStringAsync().Result;
        }

        public JToken ContentAsJson => JToken.Parse(ContentAsString);

        public T Content<T>()
        {
            try
            {
                return ContentAsJson.ToObject<T>();
            }
            catch (Exception)
            {
                throw new Exception(
                    $"Error deserializing content. StatusCode = {StatusCode} \nContent = {ContentAsString}");
            }
        }

        public void SetContentWithCustomization<T>(T obj)
        {
            ContentAsString = JsonConvert.SerializeObject(obj);
        }

        public void Ensure(HttpStatusCode httpStatusCode)
        {
            if (StatusCode != httpStatusCode)
            {
                throw new Exception($"StatusCode is {StatusCode} Content = {ContentAsString}");
            }
        }

        public override void EnsureSuccessful()
        {
            if ((int)StatusCode < 200 || (int)StatusCode >= 300)
            {
                throw new Exception(
                    $"StatusCode is {StatusCode}. Expected to be successfull. Content = {ContentAsString}");
            }
        }

        public bool IfSuccessful()
        {
            if ((int)StatusCode < 200 || (int)StatusCode >= 300)
            {
                return false;
            }
            return true;
        }
    }
}
