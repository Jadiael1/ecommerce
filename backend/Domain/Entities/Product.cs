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
    [Column("color")]
    public string Color { get; set; } = string.Empty;
    [Column("photo")]
    public string Photo { get; set; } = string.Empty;
    [Column("price")]
    public string Price { get; set; } = string.Empty;
}