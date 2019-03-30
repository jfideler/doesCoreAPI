using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DoesCoreAPI.models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;


namespace DoesCoreAPI.Controllers
{
    [Route("api/posts")]
    [EnableCors("AllowAll")]
    public class PostsController : Controller
    {
        // GET api/posts
        [HttpGet]
        public IActionResult Get()
        {
            var posts = DataRepository.Posts;
            return Ok(posts);
        }

        // GET api/posts/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var post = DataRepository.Posts.FirstOrDefault(p => p.Id == id);

            if (post != null)
            {
                return Ok(post);
            }
            else
            {
                return NotFound();
            }
        }

        // POST api/posts
        [HttpPost]
        public IActionResult Post([FromBody]Post post)
        {
            var max = DataRepository.Posts.Max(p => p.Id);
            post.Id = max + 1;

            DataRepository.Posts.Add(post);
            return Ok(post);
        }

        // PUT api/posts/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]Post post)
        {
            Post _post = DataRepository.Posts.FirstOrDefault(p => p.Id == post.Id);

            if (_post != null)
            {
                for (int index = 0; index < DataRepository.Posts.Count; index++)
                {
                    if (DataRepository.Posts[index].Id == id)
                    {
                        DataRepository.Posts[index] = post;
                        return Ok();
                    }
                }
            }

            return NotFound();
        }

        // DELETE api/posts/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (DataRepository.Posts.Any(p => p.Id == id))
            {
                Post _post = DataRepository.Posts.First(p => p.Id == id);
                DataRepository.Posts.Remove(_post);

                return Ok();
            }

            return NotFound();
        }
    }
}
