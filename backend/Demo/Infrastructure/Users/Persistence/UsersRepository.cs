using Demo.Application.Common.Interfaces;
using Demo.Application.Users.Common;
using Demo.Common.Extensions;
using Demo.Common.Helpers;
using Demo.Common.Models;
using Demo.Infrastructure.Common.Persistence;
using DevExtreme.AspNet.Data;

namespace Demo.Infrastructure.Users.Persistence;

public class UsersRepository(DataContext context) : IUsersRepository
{
    public async Task<FilteredResult> GetUsersAsync(UsersFilteringParams filteringParams, CancellationToken cancellationToken)
    {
        var query = context.Users;

        var loadOption = FilteringHelper.CreateLoadOptionsFromFilteringParams(filteringParams);
        var loadResult = await DataSourceLoader.LoadAsync(query, loadOption, cancellationToken);

        return loadResult.MapToFilteredResult();
    }
}