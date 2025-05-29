namespace Makc.Dummy.MicroserviceReader.Infrastructure.MongoDB.AppIncomingEventPayload.Entity;

/// <summary>
/// Конфигурация сущности полезной нагрузки входящего события приложения.
/// </summary>
public class AppIncomingEventPayloadEntityConfiguration : IEntityConfiguration
{
  /// <inheritdoc/>
  public void Configure()
  {
    BsonClassMap.RegisterClassMap<AppIncomingEventPayloadEntity>(classMap =>
    {
      classMap.AutoMap();

      classMap.MapIdMember(x => x.ObjectId).SetIdGenerator(StringObjectIdGenerator.Instance);

      classMap.IdMemberMap.SetSerializer(new StringSerializer(BsonType.ObjectId));
    });
  }
}
