namespace Makc.Dummy.MicroserviceReader.Domain.UseCases.AppIncomingEvent.Actions.GetList;

/// <summary>
/// Запрос действия по получению списка входящих событий приложения.
/// </summary>
/// <param name="Query">Запрос.</param>
public record AppIncomingEventGetListActionRequest(AppIncomingEventPageQuery Query) :
  IQuery<Result<AppIncomingEventPageDTO>>;
