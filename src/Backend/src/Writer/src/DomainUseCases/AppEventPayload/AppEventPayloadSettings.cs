namespace Makc.Dummy.Writer.DomainUseCases.AppEventPayload;

/// <summary>
/// Настройки полезной нагрузки события приложения.
/// </summary>
public class AppEventPayloadSettings
{
  /// <summary>
  /// Раздел порядка сортировки по умолчанию в запросе.
  /// </summary>
  public static readonly QueryOrderSection DefaultQueryOrderSection = new(nameof(AppEventPayloadEntity.Id), true);
}
