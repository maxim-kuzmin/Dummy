namespace Makc.Dummy.Reader.Infrastructure.MongoDB.AppIncomingEvent.Entity;

/// <summary>
/// Конфигурация сущности входящего события приложения.
/// </summary>
public class AppIncomingEventEntityConfiguration : IEntityConfiguration
{
  /// <inheritdoc/>
  public void Configure()
  {
    BsonClassMap.RegisterClassMap<DummyItemEntity>(classMap =>
    {
      classMap.AutoMap();

      classMap.MapIdMember(x => x.ObjectId).SetIdGenerator(StringObjectIdGenerator.Instance);
    });
  }
}
