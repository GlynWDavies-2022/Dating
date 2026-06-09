using Dating.Application.DTO;
using Dating.Domain.Entities;
using Dating.Infrastructure.Database;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using System.Text;

namespace Dating.API.Controllers;

public class AccountController(DatingSQLDBContext context) : BaseApiController
{
    [HttpPost("register")]
    public async Task<ActionResult<User>> Register(RegisterDTO registerDTO)
    {
        if (await EmailExists(registerDTO.Email))
        {
            return BadRequest("Email has already been used.");
        }

        using var hmac = new HMACSHA512();

        var user = new User
        {
            Email = registerDTO.Email,
            DisplayName = registerDTO.DisplayName,
            PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(registerDTO.Password)),
            PasswordSalt = hmac.Key
        };

        context.Users.Add(user);

        await context.SaveChangesAsync();

        return Ok(user);
    }

    private async Task<bool> EmailExists(string email)
    {
        return await context.Users.AnyAsync(user => EF.Functions.Like(user.Email,email));
    }

}


