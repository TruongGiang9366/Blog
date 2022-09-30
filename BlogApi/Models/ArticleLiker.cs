namespace BlogApi.Models
{
    public class ArticleLiker
    {
        public Guid UserId { get; set; }
        public User User { get; set; }
        public Article Article { get; set; }
        public Guid ArticleId { get; set; }
        public DateTime LikeAt { get; set; } = DateTime.UtcNow;
    }
}