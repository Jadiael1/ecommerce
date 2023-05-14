using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml;

namespace Domain.Entities;

public class Product
{
    [Column("id")]
    [Key]
    public int Id { get; set; }
    [Column("name")]
    [Required]
    [StringLength(100)]
    public string Name { get; set; } = string.Empty;
    [Column("description")]
    public string Description { get; set; } = string.Empty;
    [Column("amount")]
    public int Amount { get; set; }
    [Column("photo")]
    public string Photo { get; set; } = string.Empty;
    [Required]
    [Column("price", TypeName = "decimal(18, 2)")]
    public decimal Price { get; set; }
    [Column("technical_information")]
    public string TechnicalInformation { get; set; } = string.Empty;
    public int UserId { get; set; }
    [ForeignKey(nameof(UserId))]
    [InverseProperty("Products")]
    public virtual User User { get; set; }
    [Column("created_at")]
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    [Column("updated_at")]
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
}