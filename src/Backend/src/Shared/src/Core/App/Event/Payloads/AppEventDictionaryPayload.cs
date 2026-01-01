namespace Makc.Dummy.Shared.Core.App.Event.Payloads;

/// <summary>
/// Словарная полезная нагрузка события приложения.
/// </summary>
public record AppEventDictionaryPayload : AppEventPayload
{
  /// <summary>
  /// Данные.
  /// </summary>
  public Dictionary<string, string?> Data { get; }

  /// <summary>
  /// Конструктор.
  /// </summary>
  public AppEventDictionaryPayload() : this([])
  {
  }

  /// <summary>
  /// Клнструктор.
  /// </summary>
  /// <param name="data">Данные.</param>
  public AppEventDictionaryPayload(Dictionary<string, string?>? data)
  {
    Data = data ?? [];
  }
}
