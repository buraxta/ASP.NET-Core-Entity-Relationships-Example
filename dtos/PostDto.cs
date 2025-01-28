using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace asp.net_db_deneme.dtos
{
    public class PostDto
    {
        public int PostId { get; set; }
        public string Content { get; set; }
        public int BlogId { get; set; } // Foreign key to Blog
    }
}
