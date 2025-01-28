using asp.net_db_deneme.data;
using asp.net_db_deneme.models;

public static class DatabaseSeeder
{
    public static void Seed(ApplicationDbContext context)
    {
        // Ensure the database is created
        context.Database.EnsureCreated();

        // Check if data already exists
        if (!context.Users.Any() && !context.Blogs.Any() && !context.Students.Any())
        {
            // One-to-One Example
            var user1 = new User { UserName = "JohnDoe" };
            var user2 = new User { UserName = "JaneDoe" };
            var userProfile1 = new UserProfile { Bio = "Software Developer", User = user1 };
            var userProfile2 = new UserProfile { Bio = "Graphic Designer", User = user2 };

            context.Users.AddRange(user1, user2);
            context.UserProfiles.AddRange(userProfile1, userProfile2);

            // One-to-Many Example
            var blog1 = new Blog { Title = "Tech Blog" };
            var blog2 = new Blog { Title = "Travel Blog" };
            var post1 = new Post { Content = "EF Core Relationships", Blog = blog1 };
            var post2 = new Post { Content = "ASP.NET Tips", Blog = blog1 };
            var post3 = new Post { Content = "Exploring Europe", Blog = blog2 };

            context.Blogs.AddRange(blog1, blog2);
            context.Posts.AddRange(post1, post2, post3);

            // Many-to-Many Example
            var student1 = new Student { Name = "Alice" };
            var student2 = new Student { Name = "Bob" };
            var course1 = new Course { CourseName = "Mathematics" };
            var course2 = new Course { CourseName = "Physics" };
            var course3 = new Course { CourseName = "Chemistry" };

            student1.Courses.Add(course1);
            student1.Courses.Add(course2);
            student2.Courses.Add(course2);
            student2.Courses.Add(course3);

            context.Students.AddRange(student1, student2);
            context.Courses.AddRange(course1, course2, course3);

            // Save changes to the database
            context.SaveChanges();
        }
    }
}
