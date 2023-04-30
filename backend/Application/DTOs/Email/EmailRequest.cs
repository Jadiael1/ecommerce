namespace Application.DTOs.Email;

public class EmailRequest
{
    public string To { get; set; } = String.Empty;
    public string Subject { get; set; } = String.Empty;
    public string Body { get; set; } = String.Empty;
    public string From { get; set; } = String.Empty;
}

