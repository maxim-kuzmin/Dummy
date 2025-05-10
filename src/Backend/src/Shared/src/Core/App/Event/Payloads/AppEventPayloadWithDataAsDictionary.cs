namespace Makc.Dummy.Shared.Core.App.Event.Payloads;

/// <summary>
/// Полезная нагрузка события приложения с данными виде словаря.
/// </summary>
public record AppEventPayloadWithDataAsDictionary : AppEventPayload
{
  /// <summary>
  /// Данные.
  /// </summary>
  public Dictionary<string, string?> Data { get; }

  /// <summary>
  /// Конструктор.
  /// </summary>
  public AppEventPayloadWithDataAsDictionary() : this([])
  {
  }

  /// <summary>
  /// Клнструктор.
  /// </summary>
  /// <param name="data">Данные.</param>
  public AppEventPayloadWithDataAsDictionary(Dictionary<string, string?>? data)
  {
    Data = data ?? [];
  }
}
