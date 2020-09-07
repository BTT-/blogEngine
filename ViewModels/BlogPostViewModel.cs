using System;
namespace Blog.ViewModels
{
    public class BlogPostViewModel
    {
        public BlogPostViewModel()
        {
        }

        public string Title { get; set; }
        public string Content { get; set; }
        public string Excerpt { get; set; }
        public DateTime PublishDate { get; set; }
        public bool Public { get; set; }

    }
}
