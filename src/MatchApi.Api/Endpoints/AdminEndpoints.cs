using MatchApi.Application.Features.Admins.Commands.RegisterAdmin;
using MediatR;

namespace MatchApi.Api.Endpoints;

public static class AdminEndpoints
{
    public static IEndpointRouteBuilder MapAdminEndpoints(
        this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/api/admin")
            .WithTags("AdminRegistration");

        group.MapPost(
            "/register",
            async (
                RegisterAdminCommand command,
                ISender sender) =>
            {
                var adminId = await sender.Send(command);

                return Results.Ok(new
                {
                    Id = adminId,
                    Message = "Admin registered successfully"
                });
            })
            .WithName("RegisterAdmin")
            .WithSummary("Registers a new admin user");

        return app;
    }
}