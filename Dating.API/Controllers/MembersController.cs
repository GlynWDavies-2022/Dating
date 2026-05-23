using Dating.Domain.Entities;
using Dating.Infrastructure.Database;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Dating.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class MembersController(DatingSQLDBContext context) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<IReadOnlyList<User>>> ListAll()
    {
        var members = await context.Users.ToListAsync();

        return members;
    }
}
