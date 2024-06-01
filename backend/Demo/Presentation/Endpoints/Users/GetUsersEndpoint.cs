using Demo.Application.Users.Common;
using Demo.Application.Users.Queries.GetWorkers;
using Demo.Common.Helpers;
using Demo.Common.Models;
using Demo.Contracts.Users;
using Demo.Domain.Users;
using Demo.Presentation.Endpoints.Users.Mappers;
using MediatR;

namespace Demo.Presentation.Endpoints.Users;

public static class GetUsersEndpoint
{
    public static IEndpointRouteBuilder MapGetUsers(this IEndpointRouteBuilder builder)
    {
        builder.MapGet(ApiEndpoints.Users.GetUsers, 
                async ([AsParameters] UsersFilteringParams filteringParams, ISender mediatr,
                    CancellationToken cancellationToken) =>
                {
                    var query = new GetUsersQuery() { FilteringParams = filteringParams };
                    var result = await mediatr.Send(query, cancellationToken);

                    if (!result.IsError)
                    {
                        result.Value.data = result.Value.data.OfType<User>()
                            .Select(x => x.MapToUserResponse());
                    }

                    return result.Match(
                        Results.Ok,
                        ResultsHelper.Problem);
                })
            .Produces<FilteredResult<UserResponse>>()
            .WithName(nameof(ApiEndpoints.Users.GetUsers));

        return builder;
    }
}