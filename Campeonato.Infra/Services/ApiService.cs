using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Campeonato.Infra.Services
{
    public class ApiService
    {
        public HttpClient Client { get; }

        public ApiService(HttpClient client)
        {
            client.BaseAddress = new Uri("https://localhost:44366/api/");
            Client = client;
        }

        public async Task<IEnumerable<T>> GetAll<T>(string resource)
        {
            var response = await Client.GetAsync(resource);
            response.EnsureSuccessStatusCode();

            return await GetResult<IEnumerable<T>>(response);
        }

        public async Task<T> GetById<T>(string resource)
        {
            var response = await Client.GetAsync(resource);
            return await GetResult<T>(response);
        }

        public async Task Insert<T>(string resource, object content)
        {
            var response = await Client.PostAsync(resource, new StringContent(JsonConvert.SerializeObject(content), Encoding.UTF8, "application/json"));
            response.EnsureSuccessStatusCode();
        }

        public async Task Update<T>(string resource, object content)
        {
            var response = await Client.PutAsync(resource, new StringContent(JsonConvert.SerializeObject(content), Encoding.UTF8, "application/json"));
            response.EnsureSuccessStatusCode();
        }

        private static async Task<T> GetResult<T>(HttpResponseMessage response)
        {
            var responseBody = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<T>(responseBody);
        }

        public async Task Remove<T>(string resource)
        {
            var response = await Client.DeleteAsync(resource);
            response.EnsureSuccessStatusCode();
        }
    }
}
