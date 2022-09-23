using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BlogApi.Models
{
    public class Article : BaseEnity
    {
        public String Title {get;set;}
        public String Content {get; set;}
        public int ViewCount {get;set;}


        
        public Guid AuthorId { get; set; }
        public User Author {get;set;}


        public Guid CategoryId {get;set;}
        public Category Category { get; set; }


        public ICollection<Tag> Tags {get;set;}
        public ICollection<Comment> Comments { get; set; }

        public ICollection<User> Likers { get; set; }
    }
}