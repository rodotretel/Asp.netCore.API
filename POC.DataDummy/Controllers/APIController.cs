using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using POC.NetCore.Model;
using POC.NetCore.Services;

namespace POC.DataDummy.Controllers
    {
        [Route("api/[controller]")]
     
        public class APIController : Controller
    {
        private IHostingEnvironment _env;
        private IPessoaService _personService;
        public  APIController(IPessoaService PessoaService, IHostingEnvironment env)
        {
            _personService = PessoaService;
            _env = env;
        }

        // GET api/values
        [HttpGet("/")]
        //[HttpGet]
            public ActionResult Get()
            {
            IEnumerable<Pessoa> pessoas;

                try
                {

               pessoas = _personService.GetAll();


                }
                catch (Exception e)
                {

                    throw e;
                }

            return Ok(pessoas);
           // return Ok("teste");
            }


         // Post api/API
        [HttpPost("/")]
        public JsonResult Post ([FromBody] Pessoa pessoa)
        {
         
            try
            {

               pessoa =  _personService.Add(pessoa);


            }
            catch (Exception e)
            {

                throw e;
            }

            return Json(pessoa);
        }

        // Post api/API
        [HttpPost("Put")]
        public HttpResponseMessageAPI Put([FromBody] Pessoa pessoa)
        {
            HttpResponseMessageAPI resultado;

            try
            {

               resultado =  _personService.Update(pessoa);


            }
            catch (Exception e)
            {

                throw e;
            }


            return resultado;

        }



        // Post api/API
        [HttpPost("Delete")]
        public HttpResponseMessageAPI Delete([FromBody] string Id)
        {
            HttpResponseMessageAPI resultado;

            try
            {

                resultado =  _personService.Delete(Id);


            }
            catch (Exception e)
            {

                throw e;
            }

            return resultado;
        }




    }

}