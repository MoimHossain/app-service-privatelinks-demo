using System;
using System.Net.Http;

namespace ConsoleClient
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var url = "http://10.0.0.5/weatherforecast";
                var request = new HttpRequestMessage(HttpMethod.Get, url);
                request.Headers.Add("Host", "backend-moimha.azurewebsites.net");

                var client = new HttpClient();

                var response = client.SendAsync(request).Result;

                if (response.IsSuccessStatusCode)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"Status: {response.StatusCode}");
                    Console.WriteLine($"Body:  {response.Content.ReadAsStringAsync().Result}");
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine($"Status: {response.StatusCode}");
                    Console.WriteLine($"Body:  {response.Content.ReadAsStringAsync().Result}");
                }
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Exceptoin: {ex.Message}");
            }

            Console.ResetColor();

        }
    }
}
