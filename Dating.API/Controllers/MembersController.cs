using Dating.Domain.Entities;
using Dating.Infrastructure.Database;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Dating.API.Controllers;

public class MembersController(DatingSQLDBContext context) : BaseApiController
{
    [HttpGet]
    public async Task<ActionResult<IReadOnlyList<User>>> ListAll()
    {
        var members = await context.Users.ToListAsync();

        return Ok(members);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<User?>> GetById(int id)
    {
        var member = await context.Users.FindAsync(id);

        if (member == null)
        {
            return NotFound();
        }

        return Ok(member);
    }
}
