namespace Makc.Dummy.MicroserviceWriter.Apps.WebApp.AppOutgoingEvent.Endpoints.Create;

/// <summary>
/// Запрос конечной точки создания исходящего события приложения.
/// </summary>
/// <param name="Name">Имя.</param>
/// <param name="PublishedAt">Дата публикации.</param>
public record AppOutgoingEventCreateEndpointRequest(  
  string Name,
  DateTimeOffset? PublishedAt);
