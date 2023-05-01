using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities;

public class User
{
    [Column("id")]
    public int Id { get; set; }
    [Column("name")]
    public string Name { get; set; } = string.Empty;
    [Column("surname")]
    public string Surname { get; set; } = string.Empty;
    [Column("login")]
    public string Login { get; set; } = string.Empty;
    [Column("email")]
    public string Email { get; set; } = string.Empty;
    [Column("password")]
    public string Password { get; set; } = string.Empty;
    [Column("photo")]
    public string Photo { get; set; } = string.Empty;
    [Column("is_admin")]
    public bool IsAdmin { get; set; }
    [Column("is_active")]
    public bool IsActive { get; set; }
    [Column("created_at")]
    public DateTime CreatedAt { get; set; }
    [Column("updated_at")]
    public DateTime UpdatedAt { get; set; }
}