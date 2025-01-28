using asp.net_db_deneme.data;
using asp.net_db_deneme.dtos;
using asp.net_db_deneme.models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[ApiController]
[Route("[controller]")]
public class BlogsController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public BlogsController(ApplicationDbContext context)
    {
        _context = context;
    }

    // Get all blogs with their posts
    [HttpGet]
    public async Task<IActionResult> GetBlogs()
    {
        var blogs = await _context
            .Blogs.Include(b => b.Posts) // Include related Posts
            .Select(b => new BlogDto
            {
                BlogId = b.BlogId,
                Title = b.Title,
                Posts = b
                    .Posts.Select(p => new PostDto
                    {
                        PostId = p.PostId,
                        Content = p.Content,
                        BlogId = p.BlogId,
                    })
                    .ToList(),
            })
            .ToListAsync();

        return Ok(blogs);
    }

    // Create a blog with posts
    [HttpPost]
    public async Task<IActionResult> CreateBlog([FromBody] BlogDto blogDto)
    {
        var blog = new Blog
        {
            Title = blogDto.Title,
            Posts = blogDto
                .Posts.Select(p => new Post { Content = p.Content, BlogId = p.BlogId })
                .ToList(),
        };

        _context.Blogs.Add(blog);
        await _context.SaveChangesAsync();

        // Return the created blog with DTO
        var createdBlogDto = new BlogDto
        {
            BlogId = blog.BlogId,
            Title = blog.Title,
            Posts = blog
                .Posts.Select(p => new PostDto
                {
                    PostId = p.PostId,
                    Content = p.Content,
                    BlogId = p.BlogId,
                })
                .ToList(),
        };

        return CreatedAtAction(nameof(GetBlogs), new { id = blog.BlogId }, createdBlogDto);
    }

    // Add a post to a specific blog
    [HttpPost("{id}/posts")]
    public async Task<IActionResult> AddPost(int id, [FromBody] PostDto postDto)
    {
        var blog = await _context.Blogs.FindAsync(id);

        if (blog == null)
            return NotFound();

        var post = new Post { Content = postDto.Content, BlogId = blog.BlogId };

        _context.Posts.Add(post);
        await _context.SaveChangesAsync();

        // Return the created post with DTO
        var createdPostDto = new PostDto
        {
            PostId = post.PostId,
            Content = post.Content,
            BlogId = post.BlogId,
        };

        return CreatedAtAction(nameof(GetBlogs), new { id = post.PostId }, createdPostDto);
    }
}
