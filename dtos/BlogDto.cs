using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace asp.net_db_deneme.dtos
{
    public class BlogDto
    {
        public int BlogId { get; set; }
        public string Title { get; set; }
        public List<PostDto> Posts { get; set; } // List of PostDto
    }
}
