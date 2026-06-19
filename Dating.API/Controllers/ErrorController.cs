using Microsoft.AspNetCore.Mvc;

namespace Dating.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ErrorController : BaseApiController
{
    [HttpGet("authorisation")]
    public IActionResult GetAuthorisation()
    {
        return Unauthorized();
    }

    [HttpGet("not-found")]
    public IActionResult GetNotFound()
    {
        return NotFound();
    }

    [HttpGet("server-error")]
    public IActionResult GetServerError()
    {
        throw new Exception("Server error");
    }

    [HttpGet("bad-request")]
    public IActionResult GetBadRequest()
    {
        return BadRequest();
    }
}
