using Demo.Domain.Users;
using Microsoft.EntityFrameworkCore;

namespace Demo.Infrastructure.Common.Persistence;

public class DataContext : DbContext
{
    public DbSet<User> Users { get; set; }

    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        modelBuilder.Entity<User>().HasData(
            Enumerable.Range(1, 5000).Select(i => new User
            {
                Id = Guid.NewGuid(),
                Username = $"User{i}",
                Password = $"Password{i}",
                Firstname = $"FirstName{i}",
                Lastname = $"LastName{i}"
            }).ToArray());
    }
}