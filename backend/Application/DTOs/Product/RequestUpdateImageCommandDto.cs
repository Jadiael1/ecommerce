using Microsoft.AspNetCore.Http;

namespace Application.DTOs.Product;

public class RequestUpdateImageCommandDto
{
    public IFormFile Photo { get; set; }
}