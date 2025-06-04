namespace Makc.Dummy.MicroserviceWriterViaSQL.Infrastructure.EntityFramework.AppOutgoingEventPayload.Entity;

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

    builder.HasOne(x => x.AppOutgoingEvent)
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

    if (entityDbSettings.MaxLengthForConcurrencyToken > 0)
    {
      builder.Property(x => x.ConcurrencyToken).HasMaxLength(entityDbSettings.MaxLengthForConcurrencyToken);
    }

    builder.Property(x => x.Data)      
      .HasColumnName(entityDbSettings.ColumnForData);

    if (entityDbSettings.MaxLengthForData > 0)
    {
      builder.Property(x => x.Data).HasMaxLength(entityDbSettings.MaxLengthForData);
    }

    builder.Property(x => x.EntityConcurrencyTokenToDelete)
      .HasColumnName(entityDbSettings.ColumnForEntityConcurrencyTokenToDelete);

    if (entityDbSettings.MaxLengthForConcurrencyToken > 0)
    {
      builder.Property(x => x.EntityConcurrencyTokenToDelete).HasMaxLength(entityDbSettings.MaxLengthForConcurrencyToken);
    }

    builder.Property(x => x.EntityConcurrencyTokenToInsert)
      .HasColumnName(entityDbSettings.ColumnForEntityConcurrencyTokenToInsert);

    if (entityDbSettings.MaxLengthForConcurrencyToken > 0)
    {
      builder.Property(x => x.EntityConcurrencyTokenToInsert).HasMaxLength(entityDbSettings.MaxLengthForConcurrencyToken);
    }

    builder.Property(x => x.EntityId)
      .IsRequired()
      .HasColumnName(entityDbSettings.ColumnForEntityId);

    if (entityDbSettings.MaxLengthForEntityId > 0)
    {
      builder.Property(x => x.EntityId).HasMaxLength(entityDbSettings.MaxLengthForEntityId);
    }

    builder.Property(x => x.EntityName)
      .IsRequired()
      .HasColumnName(entityDbSettings.ColumnForEntityName);

    if (entityDbSettings.MaxLengthForEntityName > 0)
    {
      builder.Property(x => x.EntityId).HasMaxLength(entityDbSettings.MaxLengthForEntityName);
    }

    builder.Property(x => x.Position)
      .IsRequired()
      .HasColumnName(entityDbSettings.ColumnForPosition);
  }
}
