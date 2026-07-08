using MatchApi.Domain.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace MatchApi.Application.Features.Admins.Commands.GetAllAdmins
{
    public record GetAllAdminsQuery() : IRequest<List<AdminUserDto>>;
}
