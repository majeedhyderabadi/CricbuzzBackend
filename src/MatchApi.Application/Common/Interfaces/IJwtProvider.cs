namespace MatchApi.Application.Common.Interfaces;

public interface IJwtProvider
{
    string GenerateToken(Guid adminId, string email, string role);
}