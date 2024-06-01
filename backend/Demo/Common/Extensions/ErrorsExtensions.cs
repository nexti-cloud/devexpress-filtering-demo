using Demo.Common.Models;
using ErrorOr;

namespace Demo.Common.Extensions;

public static class ErrorsExtensions
{
    public static ApiErrorResponse MapToErrorResponse(this Error error)
    {
        return new ApiErrorResponse
        {
            Errors = [new ApiError { Message = error.Description, Slug = error.Code }]
        };
    }
    
    public static ApiErrorResponse MapToErrorResponse(this List<Error> errors)
    {
        return new ApiErrorResponse
        {
            Errors = errors.Select(error => new ApiError{Message = error.Description, Slug = error.Code}).ToList()
        };
    }
}