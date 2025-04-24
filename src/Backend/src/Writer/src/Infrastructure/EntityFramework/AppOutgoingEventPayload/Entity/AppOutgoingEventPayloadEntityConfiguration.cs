namespace Makc.Dummy.Writer.Infrastructure.EntityFramework.AppOutgoingEventPayload.Entity;

/// <summary>
/// Конфигурация сущности полезной нагрузки исходящего события приложения.
/// </summary>
public class AppOutgoingEventPayloadEntityConfiguration : IEntityTypeConfiguration<AppOutgoingEventPayloadEntity>
{
  /// <inheritdoc/>
  public void Configure(EntityTypeBuilder<AppOutgoingEventPayloadEntity> builder)
  {
    var appDbSettings = AppDbContext.GetAppDbSettings();

    var entityDbSettings = appDbSettings.Entities.AppOutgoingEventPayload;

    builder.ToTable(entityDbSettings.Table, entityDbSettings.Schema);

    builder.HasKey(e => e.Id).HasName(entityDbSettings.PrimaryKey);

    builder.HasOne(x => x.Event)
      .WithMany(x => x.Payloads)
      .HasForeignKey(x => x.AppOutgoingEventId)
      .IsRequired()
      .HasConstraintName(entityDbSettings.ForeignKeyForAppOutgoingEventId);

    builder.Property(x => x.AppOutgoingEventId)
      .IsRequired()
      .HasColumnName(entityDbSettings.ColumnForAppOutgoingEventId);

    builder.Property(x => x.ConcurrencyToken)
      .IsConcurrencyToken()
      .HasColumnName(entityDbSettings.ColumnForConcurrencyToken);

    builder.Property(x => x.Data)
      .IsRequired()      
      .HasColumnName(entityDbSettings.ColumnForData);

    if (entityDbSettings.MaxLengthForData > 0)
    {
      builder.Property(x => x.Data).HasMaxLength(entityDbSettings.MaxLengthForData);
    }
  }
}
