namespace Demo.Common.Models;

public class ApiErrorResponse
{
    public required List<ApiError> Errors { get; set; }
}

public class ApiError
{
    public required string Slug { get; set; }
    public required string Message { get; set; }
}