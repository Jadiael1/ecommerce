namespace Application.DTOs.SignIn;

public class ResponseSignInDto
{
    public Domain.Entities.User? User { get; set; }
    public string Token { get; set; } = string.Empty;
    public DateTime Expiration { get; set; }
    public string TokenType { get; set; } = string.Empty;
}