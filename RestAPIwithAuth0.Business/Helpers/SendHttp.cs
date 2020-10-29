using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace RestAPIwithAuth0.Business.Helpers
{
    public class SendHttp
    {
        public async Task<Dictionary<string, string>> SendHttpRequest(string baseUrl, string requestUri, string action, Dictionary<string, string> headers, string requestBody = null)
        {
            var response = new HttpResponseMessage();
            var result = new Dictionary<string, string>();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseUrl);
                if (headers != null)
                {
                    foreach (var item in headers)
                    {
                        client.DefaultRequestHeaders.Add(item.Key, item.Value);
                    }
                }
                if (action == "GET")
                {
                    response = await client.GetAsync(requestUri);
                }
                else if (action == "POST")
                {
                    HttpContent content = new StringContent(requestBody, Encoding.UTF8, "application/json");
                    response = await client.PostAsync(requestUri, content);
                }
                else if (action == "PUT")
                {
                    HttpContent content = new StringContent(requestBody, Encoding.UTF8, "application/json");
                    response = await client.PutAsync(requestUri, content);
                }
                else
                {
                    result.Add("InvalidRequest", "Invalid request method");
                    return result;
                }
                var json = JsonConvert.SerializeObject(await response.Content.ReadAsStringAsync());
                if (response.IsSuccessStatusCode)
                {
                    result.Add("success", json);
                }
                else
                {
                    result.Add("error", json);
                }
                return result;
            }
        }
    }
}
