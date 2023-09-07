using Application.Interfaces;
using Bogus;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Infrastructure.Persistence.Contexts;

public sealed class ApplicationDbContext : DbContext
{
    // private readonly IDateTimeService _dateTime;
    private readonly ILoggerFactory _loggerFactory;
    // private readonly string _defaultConnection;

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, IDateTimeService dateTime,
        ILoggerFactory loggerFactory, IConfiguration config) : base(options)
    {
        ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        // _dateTime = dateTime;
        _loggerFactory = loggerFactory;
        // _defaultConnection = config.GetConnectionString("DefaultConnection") ?? "";
    }


    #region TABLES

    public DbSet<User> Users => Set<User>();
    public DbSet<Product> Products => Set<Product>();
    public DbSet<ProductPhoto> ProductPhoto => Set<ProductPhoto>();

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
        var faker = new Faker();
        var usedEmails = new HashSet<string>();
        var usedLogin = new HashSet<string>();

        // rename fields in table Users
        builder.Entity<User>().ToTable("users");
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
        builder.Entity<User>().Property(u => u.CreatedAt).HasColumnType("datetime")
            .HasDefaultValueSql("CURRENT_TIMESTAMP").HasColumnName("created_at");
        builder.Entity<User>().Property(u => u.UpdatedAt).HasColumnType("datetime").HasColumnName("updated_at")
            .ValueGeneratedOnAddOrUpdate().HasDefaultValueSql("CURRENT_TIMESTAMP");

        // set unique in field
        builder.Entity<User>().HasIndex(u => u.Email).IsUnique();
        builder.Entity<User>().HasIndex(u => u.Login).IsUnique();
        // populate a user table


        var users = new List<User>();
        for (var i = 1; i <= 10; i++)
        {
            var user = new User
            {
                Id = i,
                Name = faker.Person.FirstName,
                Surname = faker.Person.LastName,
                Login = faker.Internet.UserName(),
                Email = faker.Person.Email,
                Phone = faker.Person.Phone,
                Password = BCrypt.Net.BCrypt.HashPassword("123123"),
                BirthDate = faker.Person.DateOfBirth,
                Photo = faker.Image.PlaceImgUrl(),
                IsAdmin = faker.Random.Bool(),
                IsActive = faker.Random.Bool(),
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };
            do
            {
                user.Email = faker.Internet.Email();
            } while (usedEmails.Contains(user.Email));
            usedEmails.Add(user.Email);
            
            do
            {
                user.Login = faker.Internet.UserName();
            } while (usedLogin.Contains(user.Login));
            usedLogin.Add(user.Login);
            
            users.Add(user);
        }

        builder.Entity<User>().HasData(users);

        // rename fields in table Products
        builder.Entity<Product>().ToTable("products");
        builder.Entity<Product>().Property(p => p.Id).HasColumnName("id");
        builder.Entity<Product>().Property(p => p.Name).HasColumnName("name");
        builder.Entity<Product>().Property(p => p.Description).HasColumnName("description");
        builder.Entity<Product>().Property(p => p.Amount).HasColumnName("amount");
        builder.Entity<Product>().Property(p => p.Price).HasColumnName("price").HasPrecision(5, 2);
        builder.Entity<Product>().Property(p => p.TechnicalInformation).HasColumnName("technical_information");
        builder.Entity<Product>().Property(p => p.UserId).HasColumnName("user_id");
        // builder.Entity<Product>().Property(p => p.ProductPhoto).HasColumnName("product_photos");
        builder.Entity<Product>().Property(p => p.CreatedAt).HasColumnName("created_at")
            .HasDefaultValueSql("CURRENT_TIMESTAMP");
        builder.Entity<Product>().Property(u => u.UpdatedAt).HasColumnName("updated_at")
            .HasDefaultValueSql("CURRENT_TIMESTAMP").ValueGeneratedOnAddOrUpdate();
        // populate a products table
        var products = new List<Product>();
        for (var i = 1; i <= 10; i++)
        {
            var product = new Product
            {
                Id = i,
                Name = faker.Person.FirstName,
                Description = faker.Commerce.ProductDescription(),
                Amount = faker.Random.Int(1, 10),
                Price = faker.Random.Decimal(1M, 2M),
                TechnicalInformation = faker.Lorem.Text(),
                UserId = i,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };
            products.Add(product);
        }

        builder.Entity<Product>().HasData(products);


        // rename fields in Table ProductPhoto
        builder.Entity<ProductPhoto>().ToTable("product_photos");
        builder.Entity<ProductPhoto>().Property(p => p.Id).HasColumnName("id");
        builder.Entity<ProductPhoto>().Property(p => p.Name).HasColumnName("name");
        builder.Entity<ProductPhoto>().Property(p => p.NewName).HasColumnName("new_name");
        builder.Entity<ProductPhoto>().Property(p => p.Path).HasColumnName("path");
        builder.Entity<ProductPhoto>().Property(p => p.ProductId).HasColumnName("product_id");
        builder.Entity<ProductPhoto>().Property(p => p.CreatedAt).HasColumnName("created_at")
            .HasDefaultValueSql("CURRENT_TIMESTAMP");
        builder.Entity<ProductPhoto>().Property(p => p.UpdatedAt).HasColumnName("updated_at")
            .HasDefaultValueSql("CURRENT_TIMESTAMP").ValueGeneratedOnAddOrUpdate();

        // populate a products table
        var productPhotos = new List<ProductPhoto>();
        for (var i = 1; i <= 10; i++)
        {
            var productPhoto = new ProductPhoto()
            {
                Id = i,
                Name = $"{faker.Random.Word()}.{faker.PickRandom(new string[] { "jpg", "png", "gif" })}",
                NewName = $"{faker.Random.Word()}.{faker.PickRandom(new string[] { "jpg", "png", "gif" })}",
                Path = faker.Internet.UrlRootedPath(),
                ProductId = i,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };
            productPhotos.Add(productPhoto);
        }

        builder.Entity<ProductPhoto>().HasData(productPhotos);


        builder.Entity<Product>()
            .HasMany(p => p.Photos)
            .WithOne(p => p.Product)
            .HasForeignKey(p => p.ProductId);

        builder.Entity<Product>()
            .HasOne(p => p.User)
            .WithMany(u => u.Products)
            .HasForeignKey(p => p.UserId);

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