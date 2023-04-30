namespace Domain.Settings;

public class MailSettings
{
    public string EmailFrom { get; set; } = String.Empty;
    public string SmtpHost { get; set; } = String.Empty;
    public int SmtpPort { get; set; }
    public string SmtpUser { get; set; } = String.Empty;
    public string SmtpPass { get; set; } = String.Empty;
    public string DisplayName { get; set; } = String.Empty;
}

