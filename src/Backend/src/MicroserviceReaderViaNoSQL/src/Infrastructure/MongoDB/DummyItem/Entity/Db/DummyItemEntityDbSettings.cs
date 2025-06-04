namespace Makc.Dummy.MicroserviceReaderViaNoSQL.Infrastructure.MongoDB.DummyItem.Entity.Db;

/// <summary>
/// Настройки базы данных сущности фиктивного предмета.
/// </summary>
public record DummyItemEntityDbSettings : DummyItemEntityDbNoSQLSettings
{
  /// <summary>
  /// Конструктор.
  /// </summary>
  public DummyItemEntityDbSettings()
  {
    Collection = "DummyItem";
  }
}
