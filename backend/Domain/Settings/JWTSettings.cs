namespace Domain.Settings;

public static class JWTSettings
{
    public static string Key => "C949CD2DCD7E0C13E053E701830A3A90";
    public static string Issuer { get; set; } = String.Empty;
    public static string Audience { get; set; } = String.Empty;
    public static double DurationInMinutes { get; set; }
}