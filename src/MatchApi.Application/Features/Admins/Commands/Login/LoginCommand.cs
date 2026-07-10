using MediatR;

namespace MatchApi.Application.Features.Admins.Commands.Login;

public sealed record LoginCommand(
    string Email,
    string Password
) : IRequest<LoginResponse>;