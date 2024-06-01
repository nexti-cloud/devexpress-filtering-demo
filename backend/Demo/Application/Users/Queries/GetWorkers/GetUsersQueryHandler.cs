using Demo.Application.Common.Interfaces;
using Demo.Common.Models;
using ErrorOr;
using MediatR;

namespace Demo.Application.Users.Queries.GetWorkers;

public class GetUsersQueryHandler(IUsersRepository usersRepository) : IRequestHandler<GetUsersQuery, ErrorOr<FilteredResult>>
{
    public async Task<ErrorOr<FilteredResult>> Handle(GetUsersQuery query, CancellationToken cancellationToken)
    {
        return await usersRepository.GetUsersAsync(query.FilteringParams, cancellationToken);
    }
}