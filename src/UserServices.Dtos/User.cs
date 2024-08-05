namespace UserServices.Dtos;

public record AuthResponse(string Token, string RefreshToken);

public record AuthRequest(string Email, string Password);

public record User(string Email, string password, string FirstName, string LastName, List<Role> Roles,
    List<Scope> Scopes);

public record UserRegisterRequest(string Email, string Password, string FirstName, string LastName);

public record Role(string Name);

public record Scope(string Name);