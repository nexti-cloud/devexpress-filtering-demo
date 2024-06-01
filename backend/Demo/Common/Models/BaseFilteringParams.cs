namespace Demo.Common.Models;

public class BaseFilteringParams
{
    public string? Skip { get; set; }
    public string? Take { get; set; }
    public string? RequireTotalCount { get; set; }
    public string? RequireGroupCount { get; set; }
    public string? Sort { get; set; }
    public string? Filter { get; set; }
    public string? TotalSummary { get; set; }
    public string? Group { get; set; }
    public string? GroupSummary { get; set; }
}