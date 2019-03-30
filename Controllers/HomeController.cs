using DoesCoreAPI.util;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System.Xml;
using Newtonsoft.Json;
using System.Xml.Linq;

namespace DoesCoreAPI.Controllers
{
    [Route("api/home/{sitename}/{parttype?}/{partid?}")]
    [EnableCors("AllowAll")]
    public class HomeController : Controller
    {
        private const string _page = "page";

        // GET: api/values
        [HttpGet]
        public string Get(string sitename, string parttype = null, string partid = null)
        {
            XmlNode result;
            var cm = new ContentManager(sitename);
            System.Console.Write("home...retrieving " + parttype + " for " + sitename + "...");

            parttype = parttype ?? _page;
            result = cm.nodeResult(parttype, partid);

            if (parttype == _page)
            {
                return result.FirstChild.OuterXml;
            }
            else
            {
                XDocument document = XDocument.Parse(result.OuterXml);

                if (document != null)
                {
                    string jsonLinks = JsonConvert.SerializeXNode(document);
                    return jsonLinks;
                }
            }

            return "nothing found";
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
