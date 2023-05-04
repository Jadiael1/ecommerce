using Application.Interfaces;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Infrastructure.Persistence.Contexts;

public sealed class ApplicationDbContext : DbContext
{
    private readonly IDateTimeService _dateTime;
    private readonly ILoggerFactory _loggerFactory;
    private readonly string _defaultConnection;

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, IDateTimeService dateTime,
        ILoggerFactory loggerFactory, IConfiguration config) : base(options)
    {
        ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        _dateTime = dateTime;
        _loggerFactory = loggerFactory;
        _defaultConnection = config.GetConnectionString("DefaultConnection") ?? "";
    }


    #region TABLES

    public DbSet<User> Users => Set<User>();
    public DbSet<Product> Products => Set<Product>();

    #endregion

    #region VIEWS

    #endregion

    /*
    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
    {
        foreach (var entry in ChangeTracker.Entries<AuditableBaseEntity>())
        {
            switch (entry.State)
            {
                case EntityState.Added:
                    entry.Entity.CRIADOEM = _dateTime.NowUtc;
                    entry.Entity.CRIADOPOR = 19491;
                    break;
                case EntityState.Modified:
                    entry.Entity.ATUALIZADOEM = _dateTime.NowUtc;
                    entry.Entity.ATUALIZADOPOR = 19491;
                    break;
            }
        }
        return base.SaveChangesAsync(cancellationToken);
    }
    */


    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<User>().HasIndex(u => u.Email).IsUnique();
        builder.Entity<User>().Property(u => u.CreatedAt).HasDefaultValueSql("UTC_TIMESTAMP()");
        builder.Entity<User>().Property(u => u.UpdatedAt).HasDefaultValueSql("UTC_TIMESTAMP()");
        builder.Entity<User>().Property(u => u.IsActive).HasDefaultValue(false);
        builder.Entity<User>().Property(u => u.IsAdmin).HasDefaultValue(false);
        
        /*
        builder.Entity<User>()
            .HasMany(c => c.Products)
            .WithOne(e => e.User)
            .HasForeignKey(p => p.UserId);
        */
        
       
        
        
    
        
        base.OnModelCreating(builder);
    }


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        // optionsBuilder.UseMySql(_defaultConnection, ServerVersion.AutoDetect(_defaultConnection));
        optionsBuilder.EnableSensitiveDataLogging(false);
        optionsBuilder.UseLoggerFactory(_loggerFactory);
        // optionsBuilder.LogTo(Console.WriteLine);
    }
}