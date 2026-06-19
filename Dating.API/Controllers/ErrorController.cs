using Microsoft.AspNetCore.Mvc;

namespace Dating.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ErrorController : BaseApiController
{
    [HttpGet("authorisation")]
    public IActionResult GetAuthorisation()
    {
        return Unauthorized(new ProblemDetails
        {
            Title = "Unauthorized",
            Status = 401,
            Detail = "You are not authorized to access this resource."
        });
    }

    [HttpGet("not-found")]
    public IActionResult GetNotFound()
    {
        return NotFound(new ProblemDetails
        {
            Title = "Not Found",
            Status = 404,
            Detail = "The requested resource was not found."
        });
    }

    [HttpGet("server-error")]
    public IActionResult GetServerError()
    {
        return StatusCode(500, new ProblemDetails
        {
            Title = "Internal Server Error",
            Status = 500,
            Detail = "An unexpected error occurred on the server."
        });
    }

    [HttpGet("bad-request")]
    public IActionResult GetBadRequest()
    {
        return BadRequest(new ProblemDetails
        {
            Title = "Bad Request",
            Status = 400,
            Detail = "The request could not be understood or was missing required parameters."
        });
    }
}
