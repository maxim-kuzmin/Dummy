namespace Makc.Dummy.Integration.MicroserviceReader.Domain.UseCasesForClient.AppIncomingEventPayload.Actions.GetList;

/// <summary>
/// Обработчик действия по получению списка полезных нагрузок входящего события приложения.
/// </summary>
/// <param name="_service">Сервис.</param>
public class AppIncomingEventPayloadGetListActionHandler(IAppIncomingEventPayloadQueryService _service) :
  IQueryHandler<AppIncomingEventPayloadGetListActionRequest, Result<List<AppIncomingEventPayloadSingleDTO>>>
{
  /// <inheritdoc/>
  public Task<Result<List<AppIncomingEventPayloadSingleDTO>>> Handle(
    AppIncomingEventPayloadGetListActionRequest request,
    CancellationToken cancellationToken)
  {
    return _service.GetList(request.Query, cancellationToken);
  }
}
