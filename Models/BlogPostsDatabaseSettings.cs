namespace Blog.Models
{
    public class BlogPostsDatabaseSettings : IBlogPostsDatabaseSettings
    {
        public string BlogPostsCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }

    }
}