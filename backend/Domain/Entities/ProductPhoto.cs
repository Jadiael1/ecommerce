using System.Text.Json.Serialization;

namespace Domain.Entities;

public class ProductPhoto
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string NewName { get; set; } = string.Empty;
    public string Path { get; set; } = string.Empty;
    public int ProductId { get; set; }
    [JsonIgnore]
    public Product Product { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
}