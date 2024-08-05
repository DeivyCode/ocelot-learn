using Auth.Jwt.Extension;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace UserService.Controllers;

[ApiController]
[Route("api/user/[controller]")]
public class RegisterController : ControllerBase
{
    [HttpGet, Authorize(Roles = "Admin"), RequireScope("user.read")]
    public IActionResult Get()
    {
        var response = new TestResponse(Guid.NewGuid(), HttpContext.TraceIdentifier);
        return Ok(response);
    }
}

public record struct TestResponse(Guid Id, string RequestId);