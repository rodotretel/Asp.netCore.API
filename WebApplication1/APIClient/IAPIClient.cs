using POC.NetCore.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace POC.NetCore.API
{
    public interface IAPIClient
    {
        Task<String> GetAsync();

        Task<HttpResponseMessageAPI> GetAsync(String id);

        Task<Pessoa> PostAsync(Pessoa pessoa);

        Task<HttpResponseMessageAPI> PutAsync(Pessoa pessoa);

        Task<HttpResponseMessageAPI> DeleteAsync(String id);
    }
}
