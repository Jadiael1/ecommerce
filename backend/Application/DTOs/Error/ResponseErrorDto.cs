namespace Application.DTOs.Error;

public class ResponseErrorDto
{
    public bool Succeeded { get; set; } = false;
    public string Message { get; set; } = string.Empty;
    public string[]? Errors { get; set; }
    public string[]? Data { get; set; }
}