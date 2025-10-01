
namespace Domain.Entities;

using Domain.ValueObjects;

public class User
{
    public int Id { get; set; }
    public EntityName Name { get; set; } = null!;
    public Email Email { get; set; } = null!;
    public Password PasswordHash { get; set; } = null!;
    public Role Role { get; set; } = null!;
}
