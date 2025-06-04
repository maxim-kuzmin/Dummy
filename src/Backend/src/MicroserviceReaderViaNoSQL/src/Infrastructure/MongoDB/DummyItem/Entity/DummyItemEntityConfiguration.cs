namespace Makc.Dummy.MicroserviceReaderViaNoSQL.Infrastructure.MongoDB.DummyItem.Entity;

/// <summary>
/// Конфигурация сущности фиктивного предмета.
/// </summary>
public class DummyItemEntityConfiguration : IEntityConfiguration
{
  /// <inheritdoc/>
  public void Configure()
  {
    BsonClassMap.RegisterClassMap<DummyItemEntity>(classMap =>
    {
      classMap.AutoMap();

      classMap.MapIdMember(x => x.ObjectId).SetIdGenerator(StringObjectIdGenerator.Instance);

      classMap.IdMemberMap.SetSerializer(new StringSerializer(BsonType.ObjectId));
    });
  }
}
