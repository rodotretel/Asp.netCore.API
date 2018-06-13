using POC.NetCore.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace POC.NetCore.Services
{
    public interface IPessoaService
    {
        IEnumerable<Pessoa> GetAll();
     //   Pessoa Get(int id);
        Pessoa Add(Pessoa Pessoa);
        HttpResponseMessageAPI Update(Pessoa Pessoa);
        HttpResponseMessageAPI Delete(String id);
    }
}
