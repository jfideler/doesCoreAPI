using System.IO;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace DoesCoreAPI.Controllers
{
    [Route("api/nav")]
    [EnableCors("AllowAll")]
    public class NavController : Controller
    {
        // GET: api/values
        [HttpGet]
        public string Get()
        {
            var jsonString = System.IO.File.ReadAllText(Directory.GetCurrentDirectory() + "/content/" + "links.json");
            var jsonStringTest = System.IO.File.ReadAllText("/Users/jfidele/data/DoesCoreAPI/" + "content/" + "links.json");
            System.Console.WriteLine(Directory.GetCurrentDirectory() + "/content/" + "links.json");
            System.Console.WriteLine("/Users/jfidele/data/DoesCoreAPI/" + "content/" + "links.json");
            return jsonString.ToString();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

    
    }
}
