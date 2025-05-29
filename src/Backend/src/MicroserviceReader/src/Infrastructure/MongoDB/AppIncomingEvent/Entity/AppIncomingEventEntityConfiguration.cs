namespace Makc.Dummy.MicroserviceReader.Infrastructure.MongoDB.AppIncomingEvent.Entity;

/// <summary>
/// Конфигурация сущности входящего события приложения.
/// </summary>
public class AppIncomingEventEntityConfiguration : IEntityConfiguration
{
  /// <inheritdoc/>
  public void Configure()
  {
    BsonClassMap.RegisterClassMap<AppIncomingEventEntity>(classMap =>
    {
      classMap.AutoMap();

      classMap.MapIdMember(x => x.ObjectId).SetIdGenerator(StringObjectIdGenerator.Instance);

      classMap.IdMemberMap.SetSerializer(new StringSerializer(BsonType.ObjectId));
    });
  }
}
