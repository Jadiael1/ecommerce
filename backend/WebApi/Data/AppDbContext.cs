using Microsoft.EntityFrameworkCore;
using WebApi.Data.Entities;

namespace WebApi.Data;

public class AppDbContext : DbContext
{
    private string _defaultConnection;
    public AppDbContext(DbContextOptions<AppDbContext> options, IConfiguration config) : base(options)
    {
        _defaultConnection = config.GetConnectionString("DefaultConnection") ?? "";
    }

    public DbSet<User> Users => Set<User>();

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseMySql(_defaultConnection, ServerVersion.AutoDetect(_defaultConnection));
    }
}