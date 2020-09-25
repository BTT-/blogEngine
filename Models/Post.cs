using Newtonsoft.Json;

namespace Blog.Models
{
    public class Post : Model{
        [JsonProperty("title")]
        public string Title{get; set;}
        [JsonProperty("views")]
        public int Views {get;set;} = 0;
        [JsonProperty("content")]
        public string Content {get; set;}
        [JsonProperty("excerpt")]
        public string Excerpt {get; set;}
        [JsonProperty("coverImagePath")]
        public string CoverImagePath {get; set;}
        [JsonProperty("isPublic")]
        public bool Public {get; set;}

    }
}