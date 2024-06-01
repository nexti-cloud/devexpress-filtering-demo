using Demo.Application.Users.Common;
using Demo.Common.Models;
using ErrorOr;
using MediatR;

namespace Demo.Application.Users.Queries.GetWorkers;

public class GetUsersQuery : IRequest<ErrorOr<FilteredResult>>
{
    public required UsersFilteringParams FilteringParams { get; set; }
}