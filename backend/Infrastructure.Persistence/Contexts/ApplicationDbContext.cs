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
        // rename fields in table Users
        builder.Entity<User>().Property(u => u.Id).HasColumnName("id");
        builder.Entity<User>().Property(u => u.Name).HasColumnName("name");
        builder.Entity<User>().Property(u => u.Surname).HasColumnName("surname");
        builder.Entity<User>().Property(u => u.Login).HasColumnName("login");
        builder.Entity<User>().Property(u => u.Email).HasColumnName("email");
        builder.Entity<User>().Property(u => u.Phone).HasColumnName("phone");
        builder.Entity<User>().Property(u => u.Password).HasColumnName("password");
        builder.Entity<User>().Property(u => u.BirthDate).HasColumnName("birth_date");
        builder.Entity<User>().Property(u => u.Photo).HasColumnName("photo");
        builder.Entity<User>().Property(u => u.IsAdmin).HasColumnName("is_admin").HasDefaultValue(false);
        builder.Entity<User>().Property(u => u.IsActive).HasColumnName("is_active").HasDefaultValue(false);
        builder.Entity<User>().Property<DateTime>(u => u.CreatedAt).HasColumnType("datetime")
            .HasColumnName("created_at")
            .HasDefaultValueSql("NOW()");
        builder.Entity<User>().Property<DateTime>(u => u.UpdatedAt).HasColumnType("datetime")
            .HasColumnName("updated_at")
            .HasDefaultValueSql("NOW()").ValueGeneratedOnUpdate();
        // set unique in field
        builder.Entity<User>().HasIndex(u => u.Email).IsUnique();
        // populate a user table
        var users = new List<User>();
        for (var i = 1; i <= 10; i++)
        {
            var user = new User
            {
                Id = i,
                Name = Faker.Name.First(),
                Surname = Faker.Name.Last(),
                Login = Faker.Internet.UserName(),
                Email = Faker.Internet.Email(),
                Phone = Faker.Identification.UkNhsNumber(),
                Password = Faker.Lorem.Paragraph(1),
                BirthDate = Faker.Identification.DateOfBirth(),
                Photo = "https://loremflickr.com/640/480/abstract",
                IsAdmin = Faker.Boolean.Random(),
                IsActive = Faker.Boolean.Random(),
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };
            users.Add(user);
        }

        builder.Entity<User>().HasData(users);

        // rename fields in table Products
        builder.Entity<Product>().Property(u => u.Id).HasColumnName("id");
        builder.Entity<Product>().Property(u => u.Name).HasColumnName("name");
        builder.Entity<Product>().Property(u => u.Description).HasColumnName("description");
        builder.Entity<Product>().Property(u => u.Amount).HasColumnName("amount");
        builder.Entity<Product>().Property(u => u.Photo).HasColumnName("photo");
        builder.Entity<Product>().Property(u => u.Price).HasColumnName("price");
        builder.Entity<Product>().Property(u => u.TechnicalInformation).HasColumnName("technical_information");
        builder.Entity<Product>().Property(u => u.UserId).HasColumnName("user_id");
        builder.Entity<Product>().Property(u => u.CreatedAt).HasColumnName("created_at")
            .HasDefaultValueSql("UTC_TIMESTAMP()");
        builder.Entity<Product>().Property(u => u.UpdatedAt).HasColumnName("updated_at")
            .HasDefaultValueSql("UTC_TIMESTAMP()");
        // populate a products table
        var products = new List<Product>();
        for (var i = 1; i <= 10; i++)
        {
            var product = new Product
            {
                Id = i,
                Name = Faker.Lorem.Paragraph(1),
                Description = Faker.Lorem.Paragraph(1),
                Amount = Faker.RandomNumber.Next(1, 10),
                Photo = "https://loremflickr.com/640/480/abstract",
                Price = Faker.RandomNumber.Next(10, 20),
                TechnicalInformation = Faker.Lorem.Paragraph(10),
                UserId = i,
                CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow
            };
            products.Add(product);
        }

        builder.Entity<Product>().HasData(products);

        /*
        builder.Entity<Product>()
            .HasOne(_ => _.User)
            .WithMany(u => u.Products)
            .HasForeignKey(p => p.UserId);
        
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