namespace Domain.Common;

public abstract class AuditableBaseEntity : BaseEntity
{
    public long CRIADOPOR { get; set; }
    public DateTime CRIADOEM { get; set; }
    public long ATUALIZADOPOR { get; set; }
    public DateTime? ATUALIZADOEM { get; set; }
}

