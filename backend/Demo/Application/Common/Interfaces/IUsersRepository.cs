using Demo.Application.Users.Common;
using Demo.Common.Models;

namespace Demo.Application.Common.Interfaces;

public interface IUsersRepository
{
    Task<FilteredResult> GetUsersAsync(UsersFilteringParams filteringParams, CancellationToken cancellationToken);
}