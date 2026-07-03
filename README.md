# MatchApi

A .NET 10 minimal API built with Clean Architecture, exposing a `CreateMatch` endpoint backed by SQL Server (EF Core).

## Solution layout

```
MatchApi/
  src/
    MatchApi.Domain/          # Entities, enums, no dependencies on other layers
    MatchApi.Application/     # CQRS commands/handlers (MediatR), validation (FluentValidation), interfaces
    MatchApi.Infrastructure/  # EF Core DbContext, repositories, SQL Server implementation
    MatchApi.Api/             # Minimal API host, endpoint mapping, composition root (Program.cs)
```

Dependency direction: `Api -> Infrastructure -> Application -> Domain` (Api also references Application directly for MediatR).
Domain has no outward dependencies; Application depends only on Domain and defines interfaces (`IMatchRepository`, `IUnitOfWork`) that Infrastructure implements — the classic Clean Architecture / Dependency Inversion setup.

## Prerequisites

- .NET 10 SDK
- SQL Server (local, container, or Azure SQL)

## Configure the database

Update the `ConnectionStrings:SqlServer` value in `src/MatchApi.Api/appsettings.json` (and `appsettings.Development.json`) to point at your SQL Server instance.

## Create and apply migrations

From the repository root:

```bash
dotnet tool install --global dotnet-ef   # if not already installed

dotnet ef migrations add InitialCreate \
  --project src/MatchApi.Infrastructure \
  --startup-project src/MatchApi.Api

dotnet ef database update \
  --project src/MatchApi.Infrastructure \
  --startup-project src/MatchApi.Api
```

## Run the API

```bash
dotnet run --project src/MatchApi.Api
```

By default this launches on the URLs configured by `dotnet run` (see console output). Swagger/OpenAPI JSON is available at `/openapi/v1.json` in the Development environment.

## Endpoint: CreateMatch

`POST /api/matches` (endpoint name: `CreateMatch`)

Request body:

```json
{
  "homeTeam": "Arsenal",
  "awayTeam": "Chelsea",
  "matchDateUtc": "2026-08-15T18:00:00Z",
  "venue": "Emirates Stadium"
}
```

Successful response — `201 Created`:

```json
{
  "id": "3f3a6c2e-1c2b-4b8a-9a2e-2f6d9b6a1234",
  "homeTeam": "Arsenal",
  "awayTeam": "Chelsea",
  "matchDateUtc": "2026-08-15T18:00:00Z",
  "venue": "Emirates Stadium",
  "status": "Scheduled"
}
```

Validation failure — `400 Bad Request` (RFC 7807 `ValidationProblem`), e.g. when `homeTeam` equals `awayTeam`, the match date is in the past, or required fields are missing.

## Example curl

```bash
curl -X POST https://localhost:5001/api/matches \
  -H "Content-Type: application/json" \
  -d '{
        "homeTeam": "Arsenal",
        "awayTeam": "Chelsea",
        "matchDateUtc": "2026-08-15T18:00:00Z",
        "venue": "Emirates Stadium"
      }'
```

## Notes / extension points

- Swap `MatchRepository`/`UnitOfWork` for another persistence strategy without touching `Application` or `Domain` — that's the point of the interfaces living in `Application`.
- Add more features (e.g. `GetMatchById`, `UpdateMatch`) as new folders under `Application/Features/Matches/...` plus corresponding endpoint mappings in `Api/Endpoints`.
- A MediatR `ValidationBehavior` pipeline runs FluentValidation automatically before every handler — new commands get validation for free just by adding a validator class.
