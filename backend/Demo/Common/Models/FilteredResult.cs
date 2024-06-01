using DevExtreme.AspNet.Data.ResponseModel;

namespace Demo.Common.Models;

public class FilteredResult : LoadResult
{
}

public class FilteredResult<T>
{
    public required List<T> Data { get; set; }
    public required object[] Summary { get; set; }
    public int GroupCount { get; set; }
    public int TotalCount { get; set; }
}