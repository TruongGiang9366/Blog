using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogApi.Models
{
    public class Tag : BaseEnity
    {
        public String Name {get;set;}
        public ICollection<Article> Articles {get;set;}
    }
}