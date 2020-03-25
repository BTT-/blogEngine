using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Blog.Models;
using MongoDB.Driver;

namespace Blog.Controllers
{
    [Route("/admin")]
    public class AdminController: Controller
    {

        private readonly IMongoCollection<Post> _posts;

        public AdminController(IBlogPostsDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _posts = database.GetCollection<Post>(settings.BlogPostsCollectionName);
        }

        public IActionResult Index()
        {
            return View(_posts.Find(p => true).ToList());
        }

        [HttpGet, Route("new/post")]
        public IActionResult NewPost()
        {
            return View();
        }

        [HttpPost, Route("new/post")]
        public IActionResult NewPost([FromBody]Post post)
        {
            _posts.InsertOne(post);

            if(_posts.Find(p => p.Title.Equals(post.Title)).Any())
                return StatusCode(201);

            return StatusCode(400);
        }

        [HttpDelete, Route("post/delete")]
        public IActionResult DeletePost([FromBody]string postTitle)
        {
            if(_posts.DeleteOne(p => p.Title.Equals(postTitle)).IsAcknowledged)
                return StatusCode(200);

            return StatusCode(400);
        }

        [HttpPut, Route("post/update")]
        public IActionResult UpdatePost([FromBody]Post newPost, [FromBody]string postTitle)
        {
            if(_posts.ReplaceOne(p => p.Title.Equals(postTitle), newPost).IsAcknowledged)
                return StatusCode(200);

            return StatusCode(400);
        }
    }
}