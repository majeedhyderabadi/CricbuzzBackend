using MatchApi.Application.Features.Teams.Commands.CreateTeam;
using MatchApi.Application.Features.Teams.Commands.DeleteTeam;
using MatchApi.Application.Features.Teams.Commands.UpdateTeam;
using MatchApi.Application.Features.Teams.Queries.GetTeams;
using MediatR;

namespace MatchApi.Api.Endpoints
{
    public static class TeamsEndpoints
    {
        public static IEndpointRouteBuilder MapTeamsEndpoints(this IEndpointRouteBuilder app)
        {
            var group = app.MapGroup("/api/teams")
                .WithTags("teams");

            group.MapPost("/", CreateTeam)
                .WithName("CreateTeam")
                .WithSummary("Create teams")
                .Produces<CreateTeamCommand>(StatusCodes.Status201Created)
                .ProducesValidationProblem()
                .ProducesProblem(StatusCodes.Status400BadRequest)
                .ProducesProblem(StatusCodes.Status500InternalServerError);

            group.MapGet("/", GetTeams)
                .WithName("GetTeams")
                .WithSummary("Returns all teams")
                .Produces<List<GetTeamsResponse>>(StatusCodes.Status200OK)
                .ProducesProblem(StatusCodes.Status500InternalServerError);

            group.MapDelete("/{id:guid}", DeleteTeam)
                .WithName("DeleteTeam")
                .WithSummary("Delete the team")
                .ProducesProblem(StatusCodes.Status500InternalServerError);

            group.MapPut("/{id:guid}", UpdateTeam)
                .WithName("UpdateTeam")
                .WithSummary("Updates the team")
                .ProducesProblem(StatusCodes.Status500InternalServerError);

            return app;
        }

        private static async Task<IResult> CreateTeam(
            CreateTeamCommand command,
            ISender sender,
            CancellationToken cancellationToken)
        {
            try
            {
                var response = await sender.Send(command, cancellationToken);
                return Results.Created($"/api/teams/{response.Id}", response);
            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message, statusCode: StatusCodes.Status400BadRequest);
            }
        }
        private static async Task<IResult> GetTeams(
            ISender sender,
            CancellationToken cancellationToken)
        {
            var response = await sender.Send(
                new GetTeamsQuery(),
                cancellationToken);

            return Results.Ok(response);
        }
        private static async Task<IResult> DeleteTeam(
            Guid id,
            ISender sender,
            CancellationToken cancellationToken)
        {
            await sender.Send(
                new DeleteTeamCommand(id),
                cancellationToken);

            return Results.NoContent();
        }
        private static async Task<IResult> UpdateTeam(
            Guid id,
            UpdateTeamCommand command,
            ISender sender,
            CancellationToken cancellationToken)
        {
            if (id != command.Id)
                return Results.BadRequest("Route Id and Body Id must match.");

            var updated = await sender.Send(command, cancellationToken);

            if (!updated)
                return Results.NotFound();

            return Results.NoContent();
        }
    }
}
