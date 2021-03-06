using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace ListTask.Services
{
    public class RequestService : IRequestService
    {
        public async Task<string> GetAsync(string uri)
        {
            using var httpClient = CreateHttpClientAsync();

            var response = await httpClient.GetAsync(uri);

            await HandleResponseAsync(response);

            var responseData = await response.Content.ReadAsStringAsync();
            return responseData;
        }

        public async Task<string> PostAsync(string uri, string data)
        {
            using var httpClient = CreateHttpClientAsync();
            var response = await httpClient.PostAsync(uri, new StringContent(data, Encoding.UTF8, "application/json"));

            await HandleResponseAsync(response);

            var responseData = await response.Content.ReadAsStringAsync();
            return responseData;
        }

        public async Task<string> DeleteAsync(string uri, string data)
        {
            using var httpClient = CreateHttpClientAsync();
            var response = await httpClient.PatchAsync(uri, new StringContent(data, Encoding.UTF8, "application/json"));

            await HandleResponseAsync(response);

            var responseData = await response.Content.ReadAsStringAsync();
            return responseData;
        }

        private HttpClient CreateHttpClientAsync()
        {
            var httpClient = new HttpClient();

            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            return httpClient;
        }

        private async Task HandleResponseAsync(HttpResponseMessage response)
        {
            Console.WriteLine("======== HandleResponse ========");
            Console.WriteLine($"StatusCode: {response.StatusCode}");

            var content = await response.Content.ReadAsStringAsync();
            Console.WriteLine(content);

            Console.WriteLine("========        End     ========");
        }
    }
}