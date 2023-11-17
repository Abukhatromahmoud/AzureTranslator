using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AzureTranslator
{
    public class Translator
    {
        private string json = "";
        private string endpoint;
        private string route;
        private string key;
        private JsonGenerator jsonGenerator;

        public Translator(string endpoint, string route, string key, JsonGenerator jsonGenerator)
        {
            this.endpoint = endpoint;
            this.route = route;
            this.key = key;
            this.jsonGenerator = jsonGenerator;
        }

        public async Task Translate(string lang)
        {
            using HttpClient client = new HttpClient();
            using HttpRequestMessage request = new HttpRequestMessage();
            {
                this.json = jsonGenerator.GenerateJsonString(lang);
                StringContent data = new StringContent(this.json, Encoding.UTF8, "application/json");

                request.Method = HttpMethod.Post;
                request.RequestUri = new Uri(this.endpoint + this.route);
                request.Headers.Add("Ocp-Apim-Subscription-Key", this.key);
                request.Content = data;

                HttpResponseMessage response = await client.SendAsync(request);
                string result = response.Content.ReadAsStringAsync().Result;
                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine($"Operation successful with status code: {response.StatusCode}");
                }
                else
                    Console.Write($"Error occurred. Status code: {((int)response.StatusCode)}");
            }
        }
    }
}
