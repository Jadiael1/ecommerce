namespace Domain.Settings;

public static class JWTSettings
{
    public static string Key => "C949CD2DCD7E0C13E053E701830A3A90";
    public static string Issuer { get; set; }
    public static string Audience { get; set; }
    public static double DurationInMinutes { get; set; }
}