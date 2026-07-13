namespace MatchApi.Application.Features.Admins.Commands.Login;

public sealed class LoginResponse
{
    public string Token { get; set; } = string.Empty;

    public Guid AdminId { get; set; }

    public string FirstName { get; set; } = string.Empty;

    public string LastName { get; set; } = string.Empty;

    public string Email { get; set; } = string.Empty;

    public string Role { get; set; } = "Admin";
}