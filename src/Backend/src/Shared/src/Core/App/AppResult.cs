namespace Makc.Dummy.Shared.Core.App;

/// <summary>
/// Результат приложения.
/// </summary>
/// <param name="Data">Данные.</param>
public record AppResult(Result Data)
{
  /// <summary>
  /// Полезные нагрузки.
  /// </summary>
  public List<AppEventPayloadWithDataAsDictionary> Payloads { get; } = [];
}
