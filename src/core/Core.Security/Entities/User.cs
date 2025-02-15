using Core.DataAccess.Enitities;

namespace Core.Security.Entities;

public class User : Entity<int>
{
    //public User()
    //{
    //    FirstName = string.Empty;
    //    LastName = string.Empty;
    //    Email = string.Empty;
    //    Username = string.Empty;
    //}
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string? Username { get; set; } = string.Empty;
    public byte[] PasswordHash { get; set; } = Array.Empty<byte>();
    public byte[] PasswordSalt { get; set; } = Array.Empty<byte>();
    public bool Status { get; set; }
    public string? ImageUrl { get; set; } = string.Empty;
    public ICollection<UserRole> UserRoles { get; set; } = new HashSet<UserRole>();

}
