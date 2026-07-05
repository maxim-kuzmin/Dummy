namespace Makc.Dummy.Integration.MicroserviceWriterViaSQL.Domain.UseCasesForClient.AppOutgoingEvent.Actions.GetList;

/// <summary>
/// Обработчик действия по получению списка исходящих событий приложения.
/// </summary>
/// <param name="_service">Сервис.</param>
public class AppOutgoingEventGetListActionHandler(IAppOutgoingEventQueryService _service) :
  IRequestHandler<AppOutgoingEventGetListActionRequest, Result<List<AppOutgoingEventSingleDTO>>>
{
  /// <inheritdoc/>
  public ValueTask<Result<List<AppOutgoingEventSingleDTO>>> Handle(
    AppOutgoingEventGetListActionRequest request,
    CancellationToken cancellationToken)
  {
    return new ValueTask<Result<List<AppOutgoingEventSingleDTO>>>(_service.GetList(request.Query, cancellationToken));
  }
}
