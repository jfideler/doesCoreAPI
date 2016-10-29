using System.Collections.Generic;
using DoesCoreAPI.util;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System.Xml;
using Newtonsoft.Json;
using System.Xml.Linq;

namespace DoesCoreAPI.Controllers
{
    [Route("api/home")]
    [EnableCors("AllowAll")]
    public class HomeController : Controller
    {
        // GET: api/values
        [HttpGet]
        public JsonResult Get()
        {
            var cm = new ContentManager();

            XmlDocument result = cm.nodeResult();
            XDocument document = XDocument.Parse(result.InnerXml);   
                     
            string jsonLinks = JsonConvert.SerializeXNode(document);

            return Json(jsonLinks);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
