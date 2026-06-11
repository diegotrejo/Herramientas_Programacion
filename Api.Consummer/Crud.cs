using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Consummer
{
    public static class Crud<T>
    {
        public static string Endpoint { get; set; }

        public static T Create(T data)
        {
            try
            {
                using (var httpClient = new HttpClient())
                {
                    var request = new HttpRequestMessage(HttpMethod.Post, Endpoint);
                    var contentBody = new StringContent(
                        Newtonsoft.Json.JsonConvert.SerializeObject(data),  // data --> json
                        Encoding.UTF8, 
                        "application/json"
                    );
                    request.Content = contentBody;

                    httpClient.DefaultRequestHeaders.Accept.Add(
                        new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json")
                    );

                    var response = httpClient.Send(request);

                    if (response.IsSuccessStatusCode)
                    {
                        var json = response.Content.ReadAsStringAsync().Result;
                        var result = Newtonsoft.Json.JsonConvert.DeserializeObject<T>(json); 
                        return result;
                    }
                    else
                        throw new Exception( response.ReasonPhrase );
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static T ReadById(string id)
        {
            using (var httpClient = new HttpClient()) 
            {
                var request = new HttpRequestMessage(HttpMethod.Get, $"{Endpoint}/{id}");
                var response = httpClient.Send(request);
                if (response.IsSuccessStatusCode) 
                {
                    var json = response.Content.ReadAsStringAsync().Result;
                    var result = Newtonsoft.Json.JsonConvert.DeserializeObject<T>(json);
                    return result;
                }
                else 
                    throw new Exception( response.ReasonPhrase );
            }
        }

        public static List<T> ReadAll()
        {
            using (var httpClient = new HttpClient())
            { 
                var request = new HttpRequestMessage(HttpMethod.Get, Endpoint);
                var response = httpClient.Send(request);
                if (response.IsSuccessStatusCode)
                {
                    var json = response.Content.ReadAsStringAsync().Result;
                    var result = Newtonsoft.Json.JsonConvert.DeserializeObject<List<T>>(json);
                    return result;
                }
                else 
                    throw new Exception( response.ReasonPhrase );
            }
        }

        public static bool Update(string id, T data)
        {
            using (var httpClient = new HttpClient())
            { 
                var request = new HttpRequestMessage(HttpMethod.Put, $"{Endpoint}/{id}");
                var contentBody = new StringContent(
                    Newtonsoft.Json.JsonConvert.SerializeObject(data),
                    Encoding.UTF8,
                    "application/json"
                );
                request.Content = contentBody;
                var response = httpClient.Send(request);
                if (response.IsSuccessStatusCode)
                    return true;
                else
                    throw new Exception(response.ReasonPhrase);
            }
        }

        public static bool Delete(string id)
        {
            using (var httpClient = new HttpClient())
            { 
                var request = new HttpRequestMessage(HttpMethod.Delete, $"{Endpoint}/{id}");
                var response = httpClient.Send(request);
                if (response.IsSuccessStatusCode)
                    return true;
                else 
                    throw new Exception(response.ReasonPhrase);
            }
        }
    }
}