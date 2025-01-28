using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace asp.net_db_deneme.models
{
    public class Student
    {
        public int StudentId { get; set; }
        public string Name { get; set; }
        public List<Course> Courses { get; set; } = new List<Course>();
    }
}
