using Chat_App.Api.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Chat_App.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController(DataContext context) : ControllerBase
    {
        private readonly DataContext _context = context;


        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            var users =await _context.Users.ToListAsync();
            if (users == null || !users.Any())
            {
                return NotFound("No users found.");
            }
            return Ok(users); 
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetUser(int id)
        {
            var user =await _context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound("No user found with this Id.");
            }
            return Ok(user);
        }
    }
}
