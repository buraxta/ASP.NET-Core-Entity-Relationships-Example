using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace asp.net_db_deneme.dtos
{
    public class StudentDto
    {
        public int StudentId { get; set; }
        public string Name { get; set; }
        public List<CourseDto> Courses { get; set; } = new List<CourseDto>(); // List of CourseDto
    }
}
