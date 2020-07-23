using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Frontend
{
    public class ApiAgent
    {
        private readonly IHttpClientFactory factory;
        private readonly FrontendConfiguration configuration;

        public ApiAgent(IHttpClientFactory factory, IOptions<FrontendConfiguration> configuration)
        {
            this.factory = factory;
            this.configuration = configuration.Value;
        }

        public async Task<string> GetResponseAsync()
        {
            var all = new StringBuilder();
            try
            {
                //var url = "http://backend-moimha.azurewebsites.net/weatherforecast";
                //var request = new HttpRequestMessage(HttpMethod.Get, url);

                var url = "http://10.2.0.5/weatherforecast";
                var request = new HttpRequestMessage(HttpMethod.Get, url);
                request.Headers.Add("Host", "backend-moimha.azurewebsites.net");


                all.AppendLine($"URL: {url}");


                var client = new HttpClient();

                var response = await client.SendAsync(request);

                if (response.IsSuccessStatusCode)
                {

                    all.AppendLine($"Status: {response.StatusCode}");
                    all.AppendLine($"Body:  {response.Content.ReadAsStringAsync().Result}");
                }
                else
                {
                    all.AppendLine($"Status: {response.StatusCode}");
                    all.AppendLine($"Body:  {await response.Content.ReadAsStringAsync()}");
                }
            }
            catch (Exception ex)
            {
                all.AppendLine($"Exceptoin: {ex.Message}");
            }

            return all.ToString();
        }
    }
}
