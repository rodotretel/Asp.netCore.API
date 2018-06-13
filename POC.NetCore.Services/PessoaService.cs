using GenFu;
using Newtonsoft.Json;
using POC.NetCore.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;

namespace POC.NetCore.Services
{
    public class PessoaService : IPessoaService
    {
        private List<Pessoa> Pessoas { get; set; }
        private Rabbit rabbitmq = new Rabbit();
        public PessoaService()
        {

        }

        public HttpResponseMessageAPI Get(string Id)
        {
            var file = System.IO.Path.Combine(System.Environment.CurrentDirectory, "data.json");
            var myJson = "";
            HttpResponseMessageAPI response = new HttpResponseMessageAPI();
            Pessoa pessoa;
            try
            {

                using (StreamReader responseReader = new StreamReader(file))
                {
                    myJson = responseReader.ReadToEnd();

                     List<Pessoa> listaPessoas = JsonConvert.DeserializeObject<List<Pessoa>>(myJson);

                    pessoa = listaPessoas.FirstOrDefault(_ => _.Id == Id);
                }

            }
            catch (Exception e)
            {

                throw;
            }

            if (pessoa is null)
                response.Response = new HttpResponseMessage(System.Net.HttpStatusCode.BadRequest);
            else response.Response = new HttpResponseMessage(System.Net.HttpStatusCode.OK);

            response.Data = pessoa;

            return response;
        }

        public IEnumerable<Pessoa> GetAll()
        {
            var file = System.IO.Path.Combine(System.Environment.CurrentDirectory, "data.json");
            var myJson = "";
            try
            {

                using (StreamReader responseReader = new StreamReader(file))
                {
                    myJson = responseReader.ReadToEnd();
                }

            }
            catch (Exception e)
            {

                throw;
            }


            return JsonConvert.DeserializeObject<List<Pessoa>>(myJson);
        }

        /*   public Pessoa Get(int id)
          {
              return Pessoas.First(_ => _.Id == id);
          }*/

        public Pessoa Add(Pessoa Pessoa)
        {
            
            try
            {
                Pessoa.Id = Guid.NewGuid().ToString();

                //rabbitmq.Sender(JsonConvert.SerializeObject(Pessoa));


                var file = System.IO.Path.Combine(System.Environment.CurrentDirectory, "data.json");
                var myJson = "";


                using (StreamReader responseReader = new StreamReader(file))
                {
                    myJson = responseReader.ReadToEnd();
                }

                List<Pessoa> listaPessoas = JsonConvert.DeserializeObject<List<Pessoa>>(myJson);

                if (listaPessoas is null)
                    listaPessoas = new List<Pessoa>();

                listaPessoas.Add(Pessoa);

                File.WriteAllText(file, JsonConvert.SerializeObject(listaPessoas));

         
                return Pessoa;
            }
            catch (Exception e)
            {

                throw;
            }

        }


        public HttpResponseMessageAPI Update(Pessoa Pessoa)
        {
            HttpResponseMessageAPI response = new HttpResponseMessageAPI();
            bool alterado = false;
            var file = System.IO.Path.Combine(System.Environment.CurrentDirectory, "data.json");
            var myJson = "";

            try
            {
          

                using (StreamReader responseReader = new StreamReader(file))
                {
                    myJson = responseReader.ReadToEnd();
                }

                List<Pessoa> listaPessoas = JsonConvert.DeserializeObject<List<Pessoa>>(myJson);         
              
                // var existing = listaPessoas.First(_ => _.Id == Pessoa.Id);
              
                
                foreach (Pessoa p in listaPessoas)
                {
                    if (p.Id == Pessoa.Id)
                    {
                        alterado = true;

                        p.PrimeiroNome = Pessoa.PrimeiroNome;
                        p.Endereco = Pessoa.Endereco;
                        p.Idade = Pessoa.Idade;
                        p.Cidade = Pessoa.Cidade;
                        p.Email = Pessoa.Email;
                        p.Telefone = Pessoa.Telefone;
                        p.Titulo = Pessoa.Titulo;
                    }
                }

                File.WriteAllText(file, JsonConvert.SerializeObject(listaPessoas));

             
            }
            catch (Exception e)
            {

                throw;
            }

            response.Data = Pessoa;

            if (alterado)
            response.Response = new HttpResponseMessage(System.Net.HttpStatusCode.OK);
            else
                response.Response = new HttpResponseMessage(System.Net.HttpStatusCode.BadRequest);

            return response;

        }

        public HttpResponseMessageAPI Delete(String Id)
        {
            HttpResponseMessageAPI response = new HttpResponseMessageAPI();
            var file = System.IO.Path.Combine(System.Environment.CurrentDirectory, "data.json");
            var myJson = "";

            try
            {
               
                using (StreamReader responseReader = new StreamReader(file))
                {
                    myJson = responseReader.ReadToEnd();
                }

                List<Pessoa> listaPessoas = JsonConvert.DeserializeObject<List<Pessoa>>(myJson);

                var existing = listaPessoas.FirstOrDefault(_ => _.Id == Id);
                
                if (existing != null) {
                    listaPessoas.Remove(existing);
                    response.Data = existing;
                    response.Response = new HttpResponseMessage(System.Net.HttpStatusCode.OK);
                }
                else
                    response.Response = new HttpResponseMessage(System.Net.HttpStatusCode.BadRequest);

                File.WriteAllText(file, JsonConvert.SerializeObject(listaPessoas));
            }
            catch (Exception e)
            {

                throw;
            }

            return response;

        }
    }
}
