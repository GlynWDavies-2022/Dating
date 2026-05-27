using Dating.Domain.Entities;
using Dating.Infrastructure.Database;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography;
using System.Text;

namespace Dating.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController(DatingSQLDBContext context) : BaseApiController
    {
        [HttpPost("register")]
        public async Task<ActionResult<User>> Register(string email, string displayName, string password)
        {
            using var hmac = new HMACSHA512();

            var user = new User
            {
                Email = email,
                DisplayName = displayName,
                PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password)),
                PasswordSalt = hmac.Key
            };

            context.Users.Add(user);

            await context.SaveChangesAsync();

            return Ok(user);
        }

    }
}
