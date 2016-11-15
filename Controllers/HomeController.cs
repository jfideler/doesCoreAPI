using DoesCoreAPI.util;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System.Xml;
using Newtonsoft.Json;
using System.Xml.Linq;

namespace DoesCoreAPI.Controllers
{
    [Route("api/home/{sitename}/{parttype}/{partid?}")]
    [EnableCors("AllowAll")]
    public class HomeController : Controller
    {
        // GET: api/values
        [HttpGet]
        public string Get(string sitename, string parttype=null, string partid=null)
        {
            System.Console.Write("home...retrieving " + parttype + " for " + sitename + "...");
            var cm = new ContentManager(sitename);

            XmlNode result = cm.nodeResult(parttype,partid);
            XDocument document = XDocument.Parse(result.OuterXml);

            if(document !=null){
                  string jsonLinks = JsonConvert.SerializeXNode(document);
                return jsonLinks;
            }
            
            return "nothing found";
        }

        // // GET api/values/5
        // [Route("api/home/{sitename}/id")]
        // [HttpGet("{id}")]
        // public string Get(string sitename, string id)
        // {
        //     var cm = new ContentManager();
        //     string retVal = "<section><h1>This page is under construction...</h1></section>";

        //     if(id.Contains(".")){
        //         id=id.Split('.')[0];
        //     }

        //     XmlDocument result = cm.nodeResult();
        //     //System.Console.WriteLine(result != null ? "Got result" : "got no result");

        //     XmlNodeList list = result.GetElementsByTagName("page");
        //     System.Console.WriteLine(result != null ? "Got pages " + list.Count.ToString() : "got no pages");

        //     foreach (XmlNode node in list)
        //     {
        //         if (node.Attributes != null)
        //         {
        //             var nameAttribute = node.Attributes["id"];
        //             if (nameAttribute != null && nameAttribute.Value == id){
        //                 retVal=node.InnerXml.ToString();
        //                // System.Console.WriteLine("here's the page " + node.InnerXml.ToString());  
        //                return retVal;
        //             }      
        //         }
        //     }

        //     return retVal.ToString();
        // }

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
