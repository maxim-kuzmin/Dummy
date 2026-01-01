namespace Makc.Dummy.Shared.Core.App.Command;

/// <summary>
/// Результат команды приложения.
/// </summary>
public record AppCommandResult
{
  /// <summary>
  /// Полезные нагрузки.
  /// </summary>
  public List<AppEventDictionaryPayload> Payloads { get; } = [];
}
