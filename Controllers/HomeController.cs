using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using Blog.Models;

namespace Blog.Controllers {
    [ApiController]
    [Route("[Controller]")]
    public class HomeController : ControllerBase
    {

        private readonly IMongoCollection<Post> _posts;

        public HomeController(IBlogPostsDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _posts = database.GetCollection<Post>(settings.BlogPostsCollectionName);
        }

        public async Task<IActionResult> Index()
        {
            await CreateSamplePosts();
            return Ok(_posts.Find<Post>(p => p.Public && 
                                          p.Created <= DateTime.Now && 
                                          p.Deleted == false).ToList());
        }

        private async Task CreateSamplePosts()
        {
            var postList = new List<Post>()
            {
                new Post() {
                    Title = "First Post",
                    Public = true,
                    CoverImagePath = "",
                    Excerpt = "Define the underlying",
                    Content = "Define the underlying principles that drive decisions and strategy for your design language bleeding edge onward and upward"
                },
                new Post() 
                {
                    Title = "Second Post",
                    Public = true,
                    CoverImagePath = "",
                    Excerpt = "so what's our",
                    Content = "so what's our go to market strategy?. Customer centric all hands on deck yet where the metal hits the meat define"
                },
                new Post(){
                    Title = "Not visible",
                    Public = false,
                    CoverImagePath = "", // blank
                    Excerpt = "not important",
                    Content = "not important, you should not see this post"
                },
                new Post(){
                    Title = "Third post",
                    Public = true,
                    CoverImagePath = "", // blank
                    Excerpt = "the underlying",
                    Content = "the underlying principles that drive decisions and strategy for your design language not the long pole",
                    Deleted = true // this one should also not be visible
                },
                new Post(){
                    Title = "Fourth post",
                    Public = true,
                    CoverImagePath = "", // blank
                    Excerpt = "in the future",
                    Content = "Post scheduling made super easy",
                    Created = DateTime.Now.AddMinutes(3) // Post scheduling made easy
                },
                new Post(){
                    Title = "Markdown Test",
                    Public = true,
                    CoverImagePath = "", // blank
                    Excerpt = "Let's see what markdown can do",
                    Content =   "# Hello world\n"+ 
                                "**Lorem** ipsum dolor sit"+ 
                                "amet, *consectetur* adipiscing elit. Sed"+ 
                                "eu est nec metus luctus tempus. Pellentesque"+ 
                                "at elementum sapien, ac faucibus sem"+
                                "![surprise](https://media.giphy.com/media/fdyZ3qI0GVZC0/giphy.gif)"
                }
            };
            
            if(await _posts.CountDocumentsAsync( p => true) == 0)
                await _posts.InsertManyAsync(postList);
        }

    }
}