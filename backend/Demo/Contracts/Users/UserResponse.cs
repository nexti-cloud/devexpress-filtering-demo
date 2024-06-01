namespace Demo.Contracts.Users;

public class UserResponse
{
    public Guid Id { get; set; }
    public required string Username { get; set; }
    public required string Firstname { get; set; }
    public required string Lastname { get; set; }
}