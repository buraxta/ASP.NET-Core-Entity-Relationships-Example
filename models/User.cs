using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace asp.net_db_deneme.models
{
    public class User
    {
        public int UserId { get; set; }
        public string UserName { get; set; }

        public UserProfile Profile { get; set; } // Navigation property
    }
}
