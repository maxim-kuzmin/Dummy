namespace Makc.Dummy.Integration.MicroserviceWriterViaSQL.Domain.UseCases.AppOutgoingEventPayload;

/// <summary>
/// Настройки полезной нагрузки исходящего события приложения.
/// </summary>
public class AppOutgoingEventPayloadSettings
{
  /// <summary>
  /// Поле сортировки для идентификатора исходящего события приложения.
  /// </summary>
  public const string SortFieldForAppOutgoingEventId = "AppOutgoingEventId";

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
  static AppOutgoingEventPayloadSettings()
  {
    DefaultQuerySortSection = new(SortFieldForId, true);
  }
}

