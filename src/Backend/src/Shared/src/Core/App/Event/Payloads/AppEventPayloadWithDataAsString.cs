namespace Makc.Dummy.Shared.Core.App.Event.Payloads;

/// <summary>
/// Полезная нагрузка события приложения с данными в виде строки.
/// </summary>
/// <param name="data">Данные.</param>
public record AppEventPayloadWithDataAsString(string? data = null) : AppEventPayload
{
  /// <summary>
  /// Данные.
  /// </summary>
  public string? Data { get; } = data;
}
