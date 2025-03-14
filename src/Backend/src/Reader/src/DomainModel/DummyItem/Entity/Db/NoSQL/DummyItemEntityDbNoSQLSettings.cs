namespace Makc.Dummy.Reader.DomainModel.DummyItem.Entity.Db.NoSQL;

/// <summary>
/// Настройки базы данных сущности фиктивного предмета.
/// </summary>
public abstract record DummyItemEntityDbNoSQLSettings
{
  /// <summary>
  /// Таблица.
  /// </summary>
  public string Collection { get; protected set; } = string.Empty;
}
