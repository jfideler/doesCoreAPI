using System.IO;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using DoesCoreAPI.util;
using System.Xml;
using Newtonsoft.Json;
using System.Xml.Linq;

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
            System.Console.Write("I am in nav...");
            var jsonString = System.IO.File.ReadAllText(Directory.GetCurrentDirectory() + "/content/" + "links.json");
            //var jsonStringTest = System.IO.File.ReadAllText("/Users/jfidele/data/DoesCoreAPI/" + "content/" + "links.json");
            //System.Console.WriteLine(Directory.GetCurrentDirectory() + "/content/" + "links.json");
            //System.Console.WriteLine("/Users/jfidele/data/DoesCoreAPI/" + "content/" + "links.json");
            return jsonString.ToString();
        }

        // GET api/values/5
        [HttpGet("{site}")]
        public string Get(string site)
        {
           System.Console.Write("I am in nav for " + site);
           var cm = new ContentManager(site);

            XmlNode result = cm.nodeResult("links",null);
            XDocument document = XDocument.Parse(result.ToString());

            string jsonLinks = JsonConvert.SerializeXNode(document);
            //System.Console.WriteLine(jsonLinks);

            //return Json(jsonLinks);
            return jsonLinks;
        }

        
    }
}
