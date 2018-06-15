using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using POC.NetCore.Model;
using POC.NetCore.Services;



namespace POC.NetCore.API.Controllers
{
    [Route("api/[controller]")]
    public class PessoasController : Controller
    {
        private IPessoaService _personService;
        private readonly IAPIClient _outraAPIClient;


        public PessoasController(IPessoaService PessoaService, IAPIClient outraAPIClient )
        {
            _outraAPIClient = outraAPIClient;
            _personService = PessoaService;
        
        }

        /// <summary>
        ///  Lista de Pessoas via chamada de API com Singleton de Classe HTTPClient
        /// </summary>
        /// <returns>Lista de Pessoas</returns>

        // GET api/pessoas
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            string result;
      

            try
            {
                
                result = await _outraAPIClient.GetAsync();
            }
            catch (Exception e)
            {

                throw;
            }

      
           // var client = _httpClientFactory.CreateClient(NamedHttpClients.OutraAPIClient);
            //var result = await client.GetStringAsync("/");
           // var models = _personService.GetAll();

            return Ok(result);
        }

        /// <summary>
        ///  Lista de Pessoas via chamada de API com Singleton de Classe HTTPClient
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Retorna Unica Pessoa</returns>
  
        // GET api/values
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            HttpResponseMessageAPI responseAPI;

            responseAPI = await _outraAPIClient.GetAsync(id);

            if (responseAPI.Response.IsSuccessStatusCode)
                return Ok(responseAPI.Data);
            else return BadRequest();
        }


        /// <summary>
        ///  Adiciona uma Pessoa via chamada de API com Singleton de Classe HTTPClient
        /// </summary>
        ///  <param name="model"></param>
        ///  <returns>Pessoa</returns>
        
        // POST api/pessoas
        [HttpPost]
        public async Task<IActionResult> Post(Pessoa model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var Pessoa = await _outraAPIClient.PostAsync(model);

                return CreatedAtAction("Get", new { id = Pessoa.Id }, Pessoa);
            }
            catch (Exception)
            {

                throw;
            }
      
        }


        /// <summary>
        ///  Atualiza uma Pessoa via chamada de API com Singleton de Classe HTTPClient
        /// </summary>
        ///  <param name="model"></param>
        ///  <returns>Pessoa</returns>
        
        // PUT api/pessoas
        [HttpPut]
        public async Task<IActionResult> Put(Pessoa model)
        {

            HttpResponseMessageAPI responseAPI;

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                responseAPI = await _outraAPIClient.PutAsync(model);
            }
            catch (Exception)
            {

                throw;
            }

            if (responseAPI.Response.IsSuccessStatusCode)
              return  Ok(responseAPI.Data);
            else return BadRequest();

            
        }

        /// <summary>
        ///  Deleta uma Pessoa via chamada de API com Singleton de Classe HTTPClient
        /// </summary>
        ///  <param name="id"></param>
        ///  <returns></returns>
       
        // DELETE api/values/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            HttpResponseMessageAPI responseAPI;

            try
            {
                responseAPI = await _outraAPIClient.DeleteAsync(id);
            }
            catch (Exception e)
            {

                throw;
            }


            if (responseAPI.Response.IsSuccessStatusCode)
                return Ok(responseAPI.Data);
            else return BadRequest();
        }
    }
}
