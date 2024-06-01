using Demo.Contracts.Users;
using Demo.Domain.Users;

namespace Demo.Presentation.Endpoints.Users.Mappers;

public static class UsersMappers
{
    public static UserResponse MapToUserResponse(this User user)
    {
        return new UserResponse
        {
            Id = user.Id,
            Username = user.Username,
            Firstname = user.Firstname,
            Lastname = user.Lastname,
        };
    }
}