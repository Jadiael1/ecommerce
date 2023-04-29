namespace WebApi.Data.Entities;

public class User
{
    public int id { get; set; }
    public string name { get; set; } = string.Empty;
    public string surname { get; set; } = string.Empty;
    public string login { get; set; } = string.Empty;
    public string password { get; set; } = string.Empty;
    public string email { get; set; } = string.Empty;
    public DateTime created_at { get; set; }
}