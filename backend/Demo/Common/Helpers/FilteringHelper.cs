using Demo.Common.Extensions;
using Demo.Common.Models;
using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Data.Helpers;

namespace Demo.Common.Helpers;

public static class FilteringHelper
{
    public static DataSourceLoadOptionsBase CreateLoadOptionsFromFilteringParams(BaseFilteringParams filteringParams)
    {
        var loadOptions = new DataSourceLoadOptionsBase();

        DataSourceLoadOptionsParser.Parse(loadOptions, key =>
        {
            var obj = filteringParams.GetType().GetProperty(key.ToFirstLetterToUpper());
            var val = obj?.GetValue(filteringParams);
            return obj != null && val != null
                ? val.ToString()
                : "";
        });

        return loadOptions;
    }
}