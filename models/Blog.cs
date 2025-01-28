using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace asp.net_db_deneme.models
{
    public class Blog
    {
        public int BlogId { get; set; }
        public string Title { get; set; }
        public List<Post> Posts { get; set; } // Navigation property
    }
}
