namespace Application.DTOs.Product;

public class RequestProductDto
{
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public int Amount { get; set; }
    public decimal Price { get; set; }
    public string TechnicalInformation { get; set; } = string.Empty;
}