namespace Makc.Dummy.Reader.Apps.WebApp.AppIncomingEvent.Endpoints.Update;

/// <summary>
/// Запрос конечной точки создания входящего события приложения.
/// </summary>
/// <param name="ObjectId">Идентификатор объекта.</param>
/// <param name="EventId">Идентификатор события.</param>
/// <param name="EventName">Имя события.</param>
/// <param name="LastLoadingAt">Последняя дата загрузки.</param>
/// <param name="LastLoadingError">Последняя ошибка загрузки.</param>
/// <param name="LoadedAt">Дата загрузки.</param>
/// <param name="PayloadCount">Количество полезной нагрузки.</param>
/// <param name="PayloadTotalCount">Общее количество полезной нагрузки.</param>
/// <param name="ProcessedAt">Дата обработки.</param>
public record AppIncomingEventUpdateEndpointRequest(
  string ObjectId,
  string EventId,
  string EventName,
  DateTimeOffset? LastLoadingAt,
  string? LastLoadingError,
  DateTimeOffset? LoadedAt,
  int PayloadCount,
  int PayloadTotalCount,
  DateTimeOffset? ProcessedAt);
