using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using POC.NetCore.Model;

namespace POC.NetCore.API
{
    public class APIClient : IAPIClient
    {
        private readonly HttpClient _client;

        public APIClient(HttpClient client)
        {
            _client = client;
        }

        public async Task<string> GetAsync()
        {
            try
            {
                var data = await _client.GetStringAsync("/");

                return data;
            }
            catch (HttpRequestException e)
            {

                throw;
            }
           
        }

   

        public async Task<Pessoa> PostAsync(Pessoa pessoa)
        {
            try
            {
                var json = JsonConvert.SerializeObject(pessoa);

                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var result = await _client.PostAsync("/", content);

                var texto = result.ToString();
                string responseBody = await result.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<Pessoa>(responseBody);
            }
            catch (HttpRequestException e)
            {

                throw;
            }
          
        }


        public async Task<HttpResponseMessageAPI> PutAsync(Pessoa pessoa)
        {
            try
            {
                

                var json = JsonConvert.SerializeObject(pessoa);

                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await _client.PostAsync("Put/", content);

                var texto = response.ToString();
                string responseBody = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<HttpResponseMessageAPI>(responseBody);
            }
            catch (HttpRequestException e)
            {

                throw;
            }
    
        }

        public async Task<HttpResponseMessageAPI> DeleteAsync(String id)
        {
            try
            {
                var json = JsonConvert.SerializeObject(id);

                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await _client.PostAsync("Delete/", content);
                string responseBody = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<HttpResponseMessageAPI>(responseBody);
                //  var result = await _client.DeleteAsync("/" + id.ToString());
            }
            catch (HttpRequestException e)
            {

                throw;
            }

          


        }
    }
}
