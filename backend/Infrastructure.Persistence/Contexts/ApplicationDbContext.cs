using Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Infrastructure.Persistence.Contexts;

public class ApplicationDbContext : DbContext
{
    private readonly IDateTimeService _dateTime;
    private readonly ILoggerFactory _loggerFactory;
    private readonly string _defaultConnection;
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, IDateTimeService dateTime, ILoggerFactory loggerFactory, IConfiguration config) : base(options)
    {
        ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        _dateTime = dateTime;
        _loggerFactory = loggerFactory;
        _defaultConnection = config.GetConnectionString("DefaultConnection") ?? "";
    }


    #region TABLES

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

    /*
    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<RegraComputacao>(entity =>
        {
            entity.Property(e => e.EXECUTAR)
                .HasConversion<char>(p => (char)p, p => (ETipoExecutar)p)
                .HasColumnName("EXECUTAR");

            entity.Property(e => e.TIPO_EXECUCAO)
                .HasConversion<char>(p => (char)p, p => (ETipoExecucao)p)
                .HasColumnName("TIPO_EXECUCAO");

            entity.Property(e => e.TIPO_PARAMETRO_DATA)
                .HasConversion<char>(p => (char)p, p => (ETipoParamData)p)
                .HasColumnName("TIPO_PARAMETRO_DATA");

            entity.Property(e => e.TIPO_REGRA)
                .HasConversion<char>(p => (char)p, p => (ETipoRegra)p)
                .HasColumnName("TIPO_REGRA");

            entity.Property(e => e.TIPO_PERIODICIDADE)
              .HasConversion<char>(p => (char)p, p => (ETipoPeriodicidade)p)
              .HasColumnName("TIPO_PERIODICIDADE");

        });
        base.OnModelCreating(builder);

    }
    */

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseMySql(_defaultConnection, ServerVersion.AutoDetect(_defaultConnection));
        optionsBuilder.EnableSensitiveDataLogging(true);
        optionsBuilder.UseLoggerFactory(_loggerFactory);
        // optionsBuilder.LogTo(Console.WriteLine);
    }


}
