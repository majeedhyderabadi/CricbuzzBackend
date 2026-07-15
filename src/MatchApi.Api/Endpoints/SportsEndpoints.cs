using MatchApi.Application.Features.Sport.Commands.CreateSport;
using MatchApi.Application.Features.Sport.Queries.GetSports;
using MatchApi.Application.Features.SportRole.Commands.AddSportRole;
using MatchApi.Application.Features.SportRole.Queries.GetSportRoles;
using MatchApi.Application.Features.SportRole.Queries.GetSportsRolesBySportId;
using MatchApi.Domain.DTOs;
using MediatR;

namespace MatchApi.Api.Endpoints
{
    /// <summary>
    /// Sports endpoints for the MatchApi application.
    /// </summary>
    public static class SportsEndpoints
    {
        /// <summary>
        /// Maps the sports-related endpoints to the provided IEndpointRouteBuilder.
        /// </summary>
        /// <param name="app">The app</param>
        /// <returns></returns>
        public static IEndpointRouteBuilder MapSportsEndpoints(
            this IEndpointRouteBuilder app)
        {
            var group = app.MapGroup("/api/sports")
                .WithTags("Sports");

            group.MapPost("/", CreateSport)
                 .WithName("CreateSport")
                 .Produces<ResponseResult<string>>(StatusCodes.Status201Created);

            group.MapPost("/roles", CreateSportRole)
                 .WithName("CreateSportRole")
                 .Produces<ResponseResult<string>>(StatusCodes.Status201Created);

            group.MapGet("/", GetSports);

            group.MapGet("/{sportId:guid}/roles", GetSportRolesBySportId);
            group.MapGet("/roles", GetSportRoles);

            return app;
        }

        private static async Task<IResult> CreateSport(
            CreateSportCommand command,
            ISender sender,
            CancellationToken cancellationToken)
        {
            var response = await sender.Send(command, cancellationToken);
            if (!response.Success)
                Results.BadRequest(response);

            return Results.Ok(response);
        }

        private static async Task<IResult> CreateSportRole(
            CreateSportRoleCommand command,
            ISender sender,
            CancellationToken cancellationToken)
        {
            var response = await sender.Send(command, cancellationToken);

            if (!response.Success)
                Results.BadRequest(response);

            return Results.Ok(response);
        }
        private static async Task<IResult> GetSports(
            ISender sender,
            CancellationToken cancellationToken)
        {
            var response = await sender.Send(
                new GetSportsQuery(),
                cancellationToken);

            return Results.Ok(response);
        }

        private static async Task<IResult> GetSportRolesBySportId(
        Guid sportId,
        ISender sender,
        CancellationToken cancellationToken)
        {
            var response = await sender.Send(
                new GetSportRolesBySportIdQuery(sportId),
                cancellationToken);

            return Results.Ok(response);
        }

        private static async Task<IResult> GetSportRoles(
            ISender sender,
            CancellationToken cancellationToken)
        {
            var response = await sender.Send(
                new GetSportRolesQuery(),
                cancellationToken);

            return Results.Ok(response);
        }
    }
}
