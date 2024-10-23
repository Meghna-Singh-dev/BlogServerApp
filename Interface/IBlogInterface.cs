using Blog.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Blog.Interface
{
    interface IBlogInterface
    {
        public IEnumerable<BlogPost> GetBlogPosts();
        public async Task<BlogPost> GetBlogPost(int id);
        public async Task<BlogPost> PutBlogPost(int id, BlogPost blogPost);
        public async Task<IActionResult> PostBlogPost(BlogPost blogPost);
        public async Task<IActionResult> DeleteBlogPost(int id);
    }
}
