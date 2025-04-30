namespace Makc.Dummy.Writer.Infrastructure.EntityFramework.AppOutgoingEvent.Entity;

/// <summary>
/// Конфигурация типа сущности исходящего события приложения.
/// </summary>
public class AppOutgoingEventEntityTypeConfiguration : IEntityTypeConfiguration<AppOutgoingEventEntity>
{
  /// <inheritdoc/>
  public void Configure(EntityTypeBuilder<AppOutgoingEventEntity> builder)
  {
    var appDbSettings = AppDbContext.GetAppDbSettings();

    var entityDbSettings = appDbSettings.Entities.AppOutgoingEvent;

    builder.ToTable(entityDbSettings.Table, entityDbSettings.Schema);

    builder.HasKey(e => e.Id).HasName(entityDbSettings.PrimaryKey);

    builder.Property(x => x.ConcurrencyToken)
      .IsConcurrencyToken()
      .HasColumnName(entityDbSettings.ColumnForConcurrencyToken);

    if (entityDbSettings.MaxLengthForConcurrencyToken > 0)
    {
      builder.Property(x => x.ConcurrencyToken).HasMaxLength(entityDbSettings.MaxLengthForConcurrencyToken);
    }

    builder.Property(x => x.CreatedAt)
      .IsRequired()
      .HasColumnName(entityDbSettings.ColumnForCreatedAt);

    builder.Property(x => x.Id)
      .ValueGeneratedOnAdd()
      .HasColumnName(entityDbSettings.ColumnForId);

    builder.Property(x => x.Name)
      .IsRequired()
      .HasColumnName(entityDbSettings.ColumnForName);

    if (entityDbSettings.MaxLengthForName > 0)
    {
      builder.Property(x => x.Name).HasMaxLength(entityDbSettings.MaxLengthForName);
    }

    builder.Property(x => x.PublishedAt)
      .HasColumnName(entityDbSettings.ColumnForPublishedAt);
  }
}
