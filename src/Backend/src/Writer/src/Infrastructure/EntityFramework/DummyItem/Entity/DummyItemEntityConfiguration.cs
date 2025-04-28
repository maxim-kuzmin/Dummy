namespace Makc.Dummy.Writer.Infrastructure.EntityFramework.DummyItem.Entity;

/// <summary>
/// Конфигурация сущности фиктивного предмета.
/// </summary>
public class DummyItemEntityConfiguration : IEntityTypeConfiguration<DummyItemEntity>
{
  /// <inheritdoc/>
  public void Configure(EntityTypeBuilder<DummyItemEntity> builder)
  {
    var appDbSettings = AppDbContext.GetAppDbSettings();

    var entityDbSettings = appDbSettings.Entities.DummyItem;

    builder.ToTable(entityDbSettings.Table, entityDbSettings.Schema);

    builder.HasKey(e => e.Id).HasName(entityDbSettings.PrimaryKey);

    builder.Property(x => x.ConcurrencyToken)
      .IsConcurrencyToken()
      .HasColumnName(entityDbSettings.ColumnForConcurrencyToken);

    if (entityDbSettings.MaxLengthForConcurrencyToken > 0)
    {
      builder.Property(x => x.ConcurrencyToken).HasMaxLength(entityDbSettings.MaxLengthForConcurrencyToken);
    }

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

    builder.HasIndex(x => x.Name)
      .IsUnique()
      .HasDatabaseName(entityDbSettings.UniqueIndexForName);
  }
}
