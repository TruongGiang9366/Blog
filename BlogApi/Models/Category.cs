using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogApi.Models
{
    public class Category : BaseEnity
    {
        public String Name { get; set; }
        public ICollection<Article> Articles { get; set; }

        public Guid CreatedById { get; set; }
        public User CreatedBy { get; set; }
    }
}