namespace Makc.Dummy.Shared.Core.App.Event.Payloads;

/// <summary>
/// Строковая полезная нагрузка события приложения.
/// </summary>
/// <param name="Data">Данные.</param>
public record AppEventStringPayload(string? Data = null) : AppEventPayload;
