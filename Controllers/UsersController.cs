using asp.net_db_deneme.data;
using asp.net_db_deneme.dtos;
using asp.net_db_deneme.models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace asp.net_db_deneme.Controllers;

[ApiController]
[Route("[controller]")]
public class UsersController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public UsersController(ApplicationDbContext context)
    {
        _context = context;
    }

    // Get all users with their profiles
    [HttpGet]
    public async Task<ActionResult<IEnumerable<UserDto>>> GetUsers()
    {
        var users = await _context
            .Users.Include(u => u.Profile) // Include the Profile data
            .Select(u => new UserDto
            {
                UserId = u.UserId,
                UserName = u.UserName,
                Profile = new UserProfileDto
                {
                    UserProfileId = u.Profile.UserProfileId,
                    Bio = u.Profile.Bio,
                    UserId = u.Profile.UserId,
                },
            })
            .ToListAsync();

        return users;
    }

    // GET: api/Users/5
    [HttpGet("{id}")]
    public async Task<ActionResult<UserDto>> GetUser(int id)
    {
        var user = await _context
            .Users.Include(u => u.Profile) // Include the Profile data
            .Select(u => new UserDto
            {
                UserId = u.UserId,
                UserName = u.UserName,
                Profile = new UserProfileDto
                {
                    UserProfileId = u.Profile.UserProfileId,
                    Bio = u.Profile.Bio,
                    UserId = u.Profile.UserId,
                },
            })
            .FirstOrDefaultAsync(u => u.UserId == id);

        if (user == null)
        {
            return NotFound();
        }

        return user;
    }

    // POST: api/Users
    [HttpPost]
    public async Task<ActionResult<UserDto>> CreateUser(UserDto userDto)
    {
        var user = new User
        {
            UserName = userDto.UserName,
            Profile = new UserProfile { Bio = userDto.Profile.Bio, UserId = userDto.UserId },
        };

        _context.Users.Add(user);
        await _context.SaveChangesAsync();

        // Return the created user with DTO
        var createdUserDto = new UserDto
        {
            UserId = user.UserId,
            UserName = user.UserName,
            Profile = new UserProfileDto
            {
                UserProfileId = user.Profile.UserProfileId,
                Bio = user.Profile.Bio,
                UserId = user.Profile.UserId,
            },
        };

        return CreatedAtAction(nameof(GetUser), new { id = user.UserId }, createdUserDto);
    }

    // PUT: api/Users/5
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateUser(int id, UserDto userDto)
    {
        if (id != userDto.UserId)
        {
            return BadRequest();
        }

        var user = await _context
            .Users.Include(u => u.Profile)
            .FirstOrDefaultAsync(u => u.UserId == id);

        if (user == null)
        {
            return NotFound();
        }

        user.UserName = userDto.UserName;
        user.Profile.Bio = userDto.Profile.Bio;

        _context.Entry(user).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.Users.Any(u => u.UserId == id))
            {
                return NotFound();
            }
            else
            {
                throw;
            }
        }

        return NoContent();
    }

    // DELETE: api/Users/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteUser(int id)
    {
        var user = await _context.Users.FindAsync(id);
        if (user == null)
        {
            return NotFound();
        }

        _context.Users.Remove(user);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}
