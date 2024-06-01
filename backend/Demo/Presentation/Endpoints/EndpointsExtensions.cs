using Demo.Presentation.Endpoints.Users;

namespace Demo.Presentation.Endpoints;

public static class EndpointsExtensions
{
    public static IEndpointRouteBuilder MapApiEndpoints(this IEndpointRouteBuilder builder)
    {
        return builder
            .MapGetUsers();
    }
}