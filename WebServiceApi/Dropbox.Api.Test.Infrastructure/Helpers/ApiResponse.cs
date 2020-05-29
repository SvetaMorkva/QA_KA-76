using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace TestDropboxApi.ApiFacade
{
    public class ApiResponse
    {
        public ApiResponse(HttpResponseMessage responseMessage)
        {
            StatusCode = responseMessage.StatusCode;
            ContentAsString = responseMessage.Content.ReadAsStringAsync().Result;
        }

        public HttpStatusCode StatusCode { get; }
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

        public void Ensure(HttpStatusCode httpStatusCode)
        {
            if (StatusCode != httpStatusCode)
            {
                throw new Exception($"StatusCode is {StatusCode} Content = {ContentAsString}");
            }
        }

        public void EnsureSuccessful()
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
