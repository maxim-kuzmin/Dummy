namespace Makc.Dummy.MicroserviceReader.DomainModel.DummyItem.Entity.Db.NoSQL;

/// <summary>
/// Настройки базы данных сущности фиктивного предмета.
/// </summary>
public abstract record DummyItemEntityDbNoSQLSettings : DummyItemEntitySettings
{
  /// <summary>
  /// Таблица.
  /// </summary>
  public string Collection { get; protected set; } = string.Empty;
}
