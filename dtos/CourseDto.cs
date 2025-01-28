using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace asp.net_db_deneme.dtos
{
    public class CourseDto
    {
        public int CourseId { get; set; }
        public string CourseName { get; set; }
        public List<StudentDto> Students { get; set; } = new List<StudentDto>(); // List of StudentDto
    }
}
