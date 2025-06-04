namespace Makc.Dummy.Integration.MicroserviceReaderViaNoSQL.Domain.UseCases.AppIncomingEvent.Actions.GetList;

/// <summary>
/// Запрос действия по получению списка входящих событий приложения.
/// </summary>
/// <param name="Query">Запрос.</param>
public record AppIncomingEventGetListActionRequest(AppIncomingEventListQuery Query) :
  IQuery<Result<List<AppIncomingEventSingleDTO>>>;
