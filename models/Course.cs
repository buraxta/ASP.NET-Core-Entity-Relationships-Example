using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace asp.net_db_deneme.models
{
    public class Course
    {
        public int CourseId { get; set; }
        public string CourseName { get; set; }
        public List<Student> Students { get; set; } // Navigation property
    }
}
