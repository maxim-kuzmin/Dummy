namespace Makc.Dummy.Integration.MicroserviceReaderViaNoSQL.Domain.UseCasesForClient.AppIncomingEvent.Actions.GetList;

/// <summary>
/// Обработчик действия по получению списка входящих событий приложения.
/// </summary>
/// <param name="_service">Сервис.</param>
public class AppIncomingEventGetListActionHandler(IAppIncomingEventQueryService _service) :
  IQueryHandler<AppIncomingEventGetListActionRequest, Result<List<AppIncomingEventSingleDTO>>>
{
  /// <inheritdoc/>
  public Task<Result<List<AppIncomingEventSingleDTO>>> Handle(
    AppIncomingEventGetListActionRequest request,
    CancellationToken cancellationToken)
  {
    return _service.GetList(request.Query, cancellationToken);
  }
}
