using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogApi.Models
{
    public class Comment : BaseEnity
    {
        public String Content { get; set; }
        public Guid AuthorId { get; set; }
        public User Author { get; set; }
        public Guid ArticleId { get; set; }
        public Article Article { get; set; }
    }
}