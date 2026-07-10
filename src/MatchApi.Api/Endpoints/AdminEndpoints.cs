using MatchApi.Application.Features.Admins.Commands.ApproveAdmin;
using MatchApi.Application.Features.Admins.Commands.GetAllAdmins;
using MatchApi.Application.Features.Admins.Commands.Login;
using MatchApi.Application.Features.Admins.Commands.RegisterAdmin;
using MatchApi.Application.Features.Admins.Commands.Login;
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

        group.MapPost(
    "/login",
    async (
        LoginCommand command,
        ISender sender) =>
    {
        var result = await sender.Send(command);

        return Results.Ok(result);
    })
    .WithName("LoginAdmin")
    .WithSummary("Logs in an admin user.");

        group.MapGet(
           "/approval-requests",
           async (ISender sender) =>
           {
               var result = await sender.Send(new GetPendingApprovalRequestsQuery());

               return Results.Ok(result);
           })
           .WithName("GetPendingApprovalRequests")
           .WithSummary("Gets all pending admin approval requests.");

        group.MapPut(
            "/approve/{id:guid}",
            async (Guid id, ISender sender) =>
            {
                await sender.Send(new ApproveAdminCommand(id));

                return Results.Ok(new
                {
                    Message = "Admin approved successfully."
                });
            })
            .WithName("ApproveAdmin")
            .WithSummary("Approves an admin user.");

        group.MapGet(
                    "/all",
                    async (ISender sender) =>
                    {
                        var result = await sender.Send(new GetAllAdminsQuery());

                        return Results.Ok(result);
                    })
                    .WithName("GetAllAdmins")
                    .WithSummary("Gets all admin users.");
        return app;
    }
}