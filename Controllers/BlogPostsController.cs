using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Blog.Models;
using Blog.Data;
using Blog.Interface;
using static Microsoft.AspNetCore.Hosting.Internal.HostingApplication;

namespace Blog.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class BlogPostsController : ControllerBase
    {
        private readonly IBlogInterface blogInterface;
       
        // GET: api/BlogPosts
        [HttpGet]
        public IEnumerable<BlogPost> GetBlogPosts()
        {
            return blogInterface.GetBlogPosts();
        }

        // GET: api/BlogPosts/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetBlogPost([FromRoute] int id)
        {
            CheckModelEmpty();

            var blogPost = await blogInterface.GetBlogPost(id);

            if (blogPost == null)
            {
                return NotFound();
            }

            return Ok(blogPost);
        }

        // PUT: api/BlogPosts/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBlogPost([FromRoute] int id, [FromBody] BlogPost blogPost)
        {
            CheckModelEmpty();

            if (id != blogPost.PostId)
            {
                return BadRequest();
            }
            var result = await blogInterface.PutBlogPost(id, blogPost);

            return NoContent();
        }

        // POST: api/BlogPosts
        [HttpPost]
        public IActionResult PostBlogPost([FromBody] BlogPost blogPost)
        {
            CheckModelEmpty();

            return CreatedAtAction("GetBlogPost", new { id = blogPost.PostId }, blogPost);
        }

        // DELETE: api/BlogPosts/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBlogPost([FromRoute] int id)
        {
            CheckModelEmpty();
            var result = await blogInterface.DeleteBlogPost(id);

            return Ok(result);
        }

        private IActionResult CheckModelEmpty()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            else { return null; }
        }
    }
}
