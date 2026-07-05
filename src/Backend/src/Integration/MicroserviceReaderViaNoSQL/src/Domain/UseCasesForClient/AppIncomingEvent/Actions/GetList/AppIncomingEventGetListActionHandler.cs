namespace Makc.Dummy.Integration.MicroserviceReaderViaNoSQL.Domain.UseCasesForClient.AppIncomingEvent.Actions.GetList;

/// <summary>
/// Обработчик действия по получению списка входящих событий приложения.
/// </summary>
/// <param name="_service">Сервис.</param>
public class AppIncomingEventGetListActionHandler(IAppIncomingEventQueryService _service) :
  IRequestHandler<AppIncomingEventGetListActionRequest, Result<List<AppIncomingEventSingleDTO>>>
{
  /// <inheritdoc/>
  public ValueTask<Result<List<AppIncomingEventSingleDTO>>> Handle(
    AppIncomingEventGetListActionRequest request,
    CancellationToken cancellationToken)
  {
    return new ValueTask<Result<List<AppIncomingEventSingleDTO>>>(_service.GetList(request.Query, cancellationToken));
  }
}
