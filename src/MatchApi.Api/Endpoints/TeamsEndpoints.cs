using MatchApi.Application.Features.Teams.Commands.CreateTeam;
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
    }
}
