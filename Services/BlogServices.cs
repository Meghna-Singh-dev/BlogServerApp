using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Blog.Models;
using Blog.Data;
using static Microsoft.AspNetCore.Hosting.Internal.HostingApplication;
using Blog.Interface;


namespace Blog.Services
{
    public class BlogServices: IBlogInterface
    {
        private readonly BlogPostsContext _context;
        private readonly IDataRepository<BlogPost> _repo;

        public IEnumerable<BlogPost> GetBlogPosts()
        {
            IEnumerable<BlogPost> blogPost = _context.BlogPosts.OrderByDescending(p => p.PostId);
            return blogPost;
        }
        public async Task<BlogPost> GetBlogPost(int id)
        {     
            BlogPost blogPost = await _context.BlogPosts.FindAsync(id);
            return blogPost;
        }
        public async Task<BlogPost> PutBlogPost(int id, BlogPost blogPost)
        {
           BlogPost res = new BlogPost();
                _context.Entry(blogPost).State = EntityState.Modified;

            try
            {
                _repo.Update(blogPost);
                res = await _repo.SaveAsync(blogPost);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BlogPostExists(id))
                {
                    return null;
                }
                else
                {
                    throw;
                }
            }
            return res;
        }
        public async Task<BlogPost> PostBlogPost(BlogPost blogPost)
        {

            _repo.Add(blogPost);
            return await _repo.SaveAsync(blogPost);
        }
        public async Task<BlogPost> DeleteBlogPost(int id)
        {
            var blogPost = await _context.BlogPosts.FindAsync(id);
            if (blogPost == null)
            {
                return null;
            }

            _repo.Delete(blogPost);
            return await _repo.SaveAsync(blogPost);
        }

        private bool BlogPostExists(int id)
        {
            return _context.BlogPosts.Any(e => e.PostId == id);
        }
    }
}
