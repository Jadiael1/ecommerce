namespace Application.DTOs.Error;

public class ErrorDto
{
    public bool Succeeded { get; set; }
    public string Message { get; set; } = string.Empty;
    public string[]? Errors { get; set; }
    public string[]? Data { get; set; }
}