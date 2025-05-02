namespace Makc.Dummy.Shared.Core.App.Event.Payloads;

/// <summary>
/// Полезная нагрузка события приложения с данными виде словаря.
/// </summary>
/// <param name="data">Данные.</param>
public record AppEventPayloadWithDataAsDictionary(
  Dictionary<string, string?>? data = null) : AppEventPayload
{
  /// <summary>
  /// Данные.
  /// </summary>
  public Dictionary<string, string?> Data { get; } = data ?? [];
}
