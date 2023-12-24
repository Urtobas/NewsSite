namespace NewsSite.Models
{
    public class Tag
    {
        public int Id { get; set; }
        public string TagContent { get; set; }
        public int ArticleId { get; set; }
    }
}
