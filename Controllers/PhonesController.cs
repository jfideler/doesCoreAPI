using DoesCoreAPI.util;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace DoesCoreAPI.Controllers
{
    [Route("api/phones")]
    [EnableCors("AllowAll")]
    public class PhonesController : Controller
    {
        // GET: api/values
        [HttpGet]
        public string Get()
        {
            var cm = new ContentManager();

            if (!string.IsNullOrEmpty(this.Request.QueryString.Value) )
            {
                var phoneId = this.Request.QueryString.Value.Split('=');
                return cm.DetailResult(phoneId[1]);
            }

            return cm.ListResult();
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
