using asp.net_db_deneme.data;
using asp.net_db_deneme.dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[ApiController]
[Route("[controller]")]
public class StudentsController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public StudentsController(ApplicationDbContext context)
    {
        _context = context;
    }

    // Get all students with their courses
    [HttpGet]
    public async Task<IActionResult> GetStudents()
    {
        var students = await _context
            .Students.Include(s => s.Courses) // Include related Courses
            .Select(s => new StudentDto
            {
                StudentId = s.StudentId,
                Name = s.Name,
                Courses = s
                    .Courses.Select(c => new CourseDto
                    {
                        CourseId = c.CourseId,
                        CourseName = c.CourseName,
                    })
                    .ToList(),
            })
            .ToListAsync();

        return Ok(students);
    }

    // Enroll a student in a course
    [HttpPost("{studentId}/courses/{courseId}")]
    public async Task<IActionResult> EnrollStudent(int studentId, int courseId)
    {
        var student = await _context
            .Students.Include(s => s.Courses)
            .FirstOrDefaultAsync(s => s.StudentId == studentId);
        var course = await _context.Courses.FindAsync(courseId);

        if (student == null || course == null)
            return NotFound();

        if (!student.Courses.Contains(course))
        {
            student.Courses.Add(course);
            await _context.SaveChangesAsync();
        }

        // Return the updated student with DTO
        var studentDto = new StudentDto
        {
            StudentId = student.StudentId,
            Name = student.Name,
            Courses = student
                .Courses.Select(c => new CourseDto
                {
                    CourseId = c.CourseId,
                    CourseName = c.CourseName,
                })
                .ToList(),
        };

        return Ok(studentDto);
    }

    // Get all courses with their enrolled students
    [HttpGet("courses")]
    public async Task<IActionResult> GetCourses()
    {
        var courses = await _context
            .Courses.Include(c => c.Students) // Include related Students
            .Select(c => new CourseDto
            {
                CourseId = c.CourseId,
                CourseName = c.CourseName,
                Students = c
                    .Students.Select(s => new StudentDto { StudentId = s.StudentId, Name = s.Name })
                    .ToList(),
            })
            .ToListAsync();

        return Ok(courses);
    }
}
