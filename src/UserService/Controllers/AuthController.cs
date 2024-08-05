using Auth.Jwt;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UserServices.Dtos;

namespace UserService.Controllers;

[ApiController]
[Route("auth")]
public class AuthController : ControllerBase
{
    private readonly IJwtService _jwtService;

    //Generate Local user for testing
    private readonly List<User> _users = new()
    {
        new User(
            Email: "admin@mail.com",
            password: "admin",
            FirstName: "Admin",
            LastName: "Admin",
            new List<Role> { new Role("Admin") },
            new List<Scope> { new Scope("user.wirte") }
        ),
        new User(
            Email: "user@mail.com",
            password: "user",
            FirstName: "User",
            LastName: "User",
            new List<Role> { new Role("User") },
            new List<Scope> { new Scope("user.read") }
        ),
    };


    public AuthController(IJwtService jwtService)
    {
        _jwtService = jwtService;
    }

    [HttpPost("login"), AllowAnonymous]
    public IActionResult Login([FromBody] AuthRequest request)
    {
        //Check if user exists
        var user = _users.FirstOrDefault(x => x.Email == request.Email && x.password == request.Password);
        if (user == null)
        {
            return Unauthorized(new AuthResponse("", "Invalid credentials"));
        }

        string token = _jwtService.GenerateToken(user);
        return Ok(new AuthResponse(token, ""));
    }
}