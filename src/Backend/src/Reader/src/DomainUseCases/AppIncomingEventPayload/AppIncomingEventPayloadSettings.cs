namespace Makc.Dummy.Reader.DomainUseCases.AppIncomingEventPayload;

/// <summary>
/// Настройки полезной нагрузки входящего события приложения.
/// </summary>
public class AppIncomingEventPayloadSettings
{
  /// <summary>
  /// Поле сортировки для идентификатора входящего события приложения.
  /// </summary>
  public const string SortFieldForAppIncomingEventId = "AppIncomingEventId";

  /// <summary>
  /// Поле сортировки для данных.
  /// </summary>
  public const string SortFieldForData = "Data";

  /// <summary>
  /// Поле сортировки для токена параллелизма сущности для удаления.
  /// </summary>
  public const string SortFieldForEntityConcurrencyTokenToDelete = "EntityConcurrencyTokenToDelete";

  /// <summary>
  /// Поле сортировки для токена параллелизма сущности для вставки.
  /// </summary>
  public const string SortFieldForEntityConcurrencyTokenToInsert = "EntityConcurrencyTokenToInsert";

  /// <summary>
  /// Поле сортировки для идентификатора сущности.
  /// </summary>
  public const string SortFieldForEntityId = "EntityId";

  /// <summary>
  /// Поле сортировки для имени сущности.
  /// </summary>
  public const string SortFieldForEntityName = "EntityName";

  /// <summary>
  /// Поле сортировки для идентификатора.
  /// </summary>
  public const string SortFieldForId = "Id";

  /// <summary>
  /// Поле сортировки для позиции.
  /// </summary>
  public const string SortFieldForPosition = "Position";

  /// <summary>
  /// Раздел сортировки по умолчанию в запросе.
  /// </summary>
  public static readonly QuerySortSection DefaultQuerySortSection;

  /// <summary>
  /// Конструктор.
  /// </summary>
  static AppIncomingEventPayloadSettings()
  {
    DefaultQuerySortSection = new(SortFieldForId, true);
  }
}
