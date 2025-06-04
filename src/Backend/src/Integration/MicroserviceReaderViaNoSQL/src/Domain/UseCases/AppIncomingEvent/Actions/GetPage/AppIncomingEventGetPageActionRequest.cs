namespace Makc.Dummy.Integration.MicroserviceReaderViaNoSQL.Domain.UseCases.AppIncomingEvent.Actions.GetPage;

/// <summary>
/// Запрос действия по получению страниц входящих событий приложения.
/// </summary>
/// <param name="Query">Запрос.</param>
public record AppIncomingEventGetPageActionRequest(AppIncomingEventPageQuery Query) :
  IQuery<Result<AppIncomingEventPageDTO>>;
