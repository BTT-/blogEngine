namespace Blog.Models
{
    public interface IBlogPostsDatabaseSettings
    {
        string BlogPostsCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}