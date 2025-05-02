namespace Makc.Dummy.Shared.Core.App.Command;

/// <summary>
/// Результат команды приложения.
/// </summary>
/// <param name="Data">Данные.</param>
public record AppCommandResult(Result Data)
{
  /// <summary>
  /// Полезные нагрузки.
  /// </summary>
  public List<AppEventPayloadWithDataAsDictionary> Payloads { get; } = [];
}
