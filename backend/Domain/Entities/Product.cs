using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities;

public class Product
{
    [Column("id")]
    public int Id { get; set; }
    [Column("name")]
    public string Name { get; set; } = string.Empty;
    [Column("description")]
    public string Description { get; set; } = string.Empty;
    [Column("amount")]
    public string Amount { get; set; } = string.Empty;
    [Column("photo")]
    public string Photo { get; set; } = string.Empty;
    [Column("price")]
    public string Price { get; set; } = string.Empty;
    [Column("technical_information")]
    public string TechnicalInformation { get; set; } = string.Empty;
    public int UserId { get; set; }
    public User User { get; set; }
    [Column("created_at")]
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    [Column("updated_at")]
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
}