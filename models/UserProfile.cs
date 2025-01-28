using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace asp.net_db_deneme.models
{
    public class UserProfile
    {
        public int UserProfileId { get; set; }
        public string Bio { get; set; }
        public int UserId { get; set; } // Foreign key
        public User User { get; set; } // Navigation property
    }
}
