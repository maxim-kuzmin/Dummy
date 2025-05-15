namespace Makc.Dummy.MicroserviceWriter.Apps.WebApp.AppOutgoingEvent.Endpoints.Update;

/// <summary>
/// Запрос конечной точки обновления исходящего события приложения.
/// </summary>
/// <param name="Id">Идентификатор.</param>
/// <param name="Name">Имя.</param>
/// <param name="PublishedAt">Дата публикации.</param>
public record AppOutgoingEventUpdateEndpointRequest(
  long Id,
  string Name,
  DateTimeOffset? PublishedAt);
