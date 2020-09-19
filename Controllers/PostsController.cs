using System;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using Blog.Models;


namespace Blog.Controllers
{
    public class PostController : Controller
    {

        private readonly IMongoCollection<Post> _posts;

        public PostController(IBlogPostsDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _posts = database.GetCollection<Post>(settings.BlogPostsCollectionName);
        }

        [Route("/post/{postTitle}")]
        public IActionResult Index([FromRoute] string postTitle)
        {
            return View(_posts.Find<Post>(p => p.Title.Equals(postTitle.Replace('-', ' '))).FirstOrDefault());
        }
    }
}