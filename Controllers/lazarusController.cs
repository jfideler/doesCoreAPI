using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

namespace DoesCoreApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LazarusController : ControllerBase
    {
        // GET api/values
        // [EnableCors]  
        [HttpGet]
        public ActionResult<string> Get()
        {
            var jsonString = System.IO.File.ReadAllText(Directory.GetCurrentDirectory() + "/assets/lazarus/works.json");
            return jsonString.ToString();
        }

        // GET api/values/5
        // [EnableCors]  
        [HttpGet("{id}")]
        public ActionResult<string> Get(string id)
        {
            var jsonString = System.IO.File.ReadAllText(Directory.GetCurrentDirectory() + "/assets/lazarus/works.json");
            var objects = JArray.Parse(jsonString); // parse as array 

            var result = "value: " + id;
            foreach (JObject root in objects)
            {
                var item = JObject.Parse(root.ToString());
                var index = (string)item["index"];
                if(index == id){
                    result = root.ToString();
                    break;
                }
            }
            
            return result;
        }

    }
}
