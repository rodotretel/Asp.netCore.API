using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using POC.NetCore.Model;

namespace POC.DummyData.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DummyController : ControllerBase
    {
        private IHostingEnvironment _env;

        // GET api/values
        [HttpGet]
        public ActionResult Get()
        {
            List<Pessoa> pessoas;

            try
            {
                var file = System.IO.Path.Combine(_env.WebRootPath, "data.json");
                pessoas = JsonConvert.DeserializeObject<List<Pessoa>>(file);
            }
            catch (Exception)
            {

                throw;
            }

            return Ok(pessoas);
        }

       public  DummyController (IHostingEnvironment env)
        {
            _env = env;
        }


      
    }
}
