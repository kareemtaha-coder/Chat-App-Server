using Chat_App.Api.Data;
using Chat_App.Api.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography;

namespace Chat_App.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController(DataContext context) : BaseApiController
    {
        [HttpPost("register")]
        public async Task<IActionResult> Register(string username, string password)
        {
            // Here you would typically call a service to handle the registration logic
            // For example, saving the user to the database and hashing the password
              var hmac = new HMACSHA512();
            var user = new AppUser
            {
                UserName = username,
                PasswordHash = System.Text.Encoding.UTF8.GetBytes(password),
                PasswordSalt = hmac.Key
            };
            context.Users.Add(user);
            await context.SaveChangesAsync();
            return Ok(new { Message = $"User registered successfully : {user} " });
        }
    }
}
