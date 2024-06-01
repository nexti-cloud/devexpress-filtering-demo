using Demo.Common.Models;
using DevExtreme.AspNet.Data.ResponseModel;

namespace Demo.Common.Extensions;

public static class FilteringExtensions
{
    public static FilteredResult MapToFilteredResult(this LoadResult loadResult)
    {
        return new FilteredResult
        {
            data = loadResult.data,
            summary = loadResult.summary,
            groupCount = loadResult.groupCount,
            totalCount = loadResult.totalCount
        };
    }
}