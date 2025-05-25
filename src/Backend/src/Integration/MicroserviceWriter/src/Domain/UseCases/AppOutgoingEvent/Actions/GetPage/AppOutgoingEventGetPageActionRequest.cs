namespace Makc.Dummy.Integration.MicroserviceWriter.Domain.UseCases.AppOutgoingEvent.Actions.GetPage;

/// <summary>
/// Запрос действия по получению страницы исходящих событий приложения.
/// </summary>
/// <param name="Query">Запрос.</param>
public record AppOutgoingEventGetPageActionRequest(AppOutgoingEventPageQuery Query) :
  IQuery<Result<AppOutgoingEventPageDTO>>;
