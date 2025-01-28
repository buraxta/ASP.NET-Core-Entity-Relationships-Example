using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace asp.net_db_deneme.dtos
{
    public class UserProfileDto
    {
        public int UserProfileId { get; set; }
        public string Bio { get; set; }
        public int UserId { get; set; } // Foreign key to
    }
}
