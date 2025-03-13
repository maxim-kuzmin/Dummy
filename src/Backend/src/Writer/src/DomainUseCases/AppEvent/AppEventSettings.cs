namespace Makc.Dummy.Writer.DomainUseCases.AppEvent;

/// <summary>
/// Настройки события приложения.
/// </summary>
public class AppEventSettings
{
  /// <summary>
  /// Раздел порядка сортировки по умолчанию в запросе.
  /// </summary>
  public static readonly QueryOrderSection DefaultQueryOrderSection = new(nameof(AppEventEntity.Id), true);
}
