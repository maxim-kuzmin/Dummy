namespace Makc.Dummy.Shared.Infrastructure.MongoDB.Entity;

/// <summary>
/// Конфигурация сущности.
/// </summary>
public class EntityConfiguration<T> : IEntityConfiguration where T : EntityBaseWithObjectIdAsStringPrimaryKey
{
  /// <inheritdoc/>
  public void Configure()
  {
    BsonClassMap.RegisterClassMap<T>(classMap =>
    {
      classMap.AutoMap();

      classMap.MapIdMember(с => с.ObjectId).SetIdGenerator(StringObjectIdGenerator.Instance);

      Map(classMap);
    });
  }

  /// <summary>
  /// Поставить в соотетствие.
  /// </summary>
  /// <param name="classMap">Карта соответствия класса.</param>
  protected virtual void Map(BsonClassMap<T> classMap)
  {
  }
}
