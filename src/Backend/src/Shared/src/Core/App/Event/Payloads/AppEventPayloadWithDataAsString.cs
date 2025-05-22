namespace Makc.Dummy.Shared.Core.App.Event.Payloads;

/// <summary>
/// Полезная нагрузка события приложения с данными в виде строки.
/// </summary>
/// <param name="Data">Данные.</param>
public record AppEventPayloadWithDataAsString(string? Data = null) : AppEventPayload;
