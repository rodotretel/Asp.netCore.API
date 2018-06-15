using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
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

        // GET api/API
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

        // GET api/API
        [HttpGet("/{id}")]
        //[HttpGet]
        public HttpResponseMessageAPI Get(string id)
        {
            HttpResponseMessageAPI response;
           
            try
            {

                response = _personService.Get(id);


            }
            catch (Exception e)
            {

                throw e;
            }

            return response;
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