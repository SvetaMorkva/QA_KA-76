using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Net;
using System.Net.Http;

namespace TestDropboxApi.ApiFacade
{
    public class BasicResponse
    {
        public HttpStatusCode StatusCode { get; }

        public BasicResponse(HttpResponseMessage responseMessage)
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

        public virtual void Ensure(HttpStatusCode httpStatusCode)
        {
            if (StatusCode != httpStatusCode)
            {
                throw new Exception($"StatusCode is {StatusCode}");
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
    public class ApiResponse: BasicResponse
    {
        public ApiResponse(HttpResponseMessage responseMessage): base(responseMessage)
        {
            ContentAsString = responseMessage.Content.ReadAsStringAsync().Result;
        }

        public string ContentAsString { get; private set; }
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

        public override void Ensure(HttpStatusCode httpStatusCode)
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
    }
}
