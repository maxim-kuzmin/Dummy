namespace Makc.Dummy.Integration.MicroserviceWriter.Domain.UseCasesForClient.AppOutgoingEvent.Actions.GetList;

/// <summary>
/// Обработчик действия по получению списка исходящих событий приложения.
/// </summary>
/// <param name="_service">Сервис.</param>
public class AppOutgoingEventGetListActionHandler(IAppOutgoingEventQueryService _service) :
  IQueryHandler<AppOutgoingEventGetListActionRequest, Result<List<AppOutgoingEventSingleDTO>>>
{
  /// <inheritdoc/>
  public Task<Result<List<AppOutgoingEventSingleDTO>>> Handle(
    AppOutgoingEventGetListActionRequest request,
    CancellationToken cancellationToken)
  {
    return _service.GetList(request.Query, cancellationToken);
  }
}
