using System.Text.Json.Serialization;

namespace Domain.Entities;

public class Product
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public int Amount { get; set; }
    public decimal Price { get; set; }
    public string TechnicalInformation { get; set; } = string.Empty;
    public int UserId { get; set; }
    [JsonIgnore]
    public User User { get; set; }
    public List<ProductPhoto> Photos { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
}