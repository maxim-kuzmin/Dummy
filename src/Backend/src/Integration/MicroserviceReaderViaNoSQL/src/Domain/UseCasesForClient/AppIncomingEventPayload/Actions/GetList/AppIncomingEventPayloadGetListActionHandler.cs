namespace Makc.Dummy.Integration.MicroserviceReaderViaNoSQL.Domain.UseCasesForClient.AppIncomingEventPayload.Actions.GetList;

/// <summary>
/// Обработчик действия по получению списка полезных нагрузок входящего события приложения.
/// </summary>
/// <param name="_service">Сервис.</param>
public class AppIncomingEventPayloadGetListActionHandler(IAppIncomingEventPayloadQueryService _service) :
  IRequestHandler<AppIncomingEventPayloadGetListActionRequest, Result<List<AppIncomingEventPayloadSingleDTO>>>
{
  /// <inheritdoc/>
  public ValueTask<Result<List<AppIncomingEventPayloadSingleDTO>>> Handle(
    AppIncomingEventPayloadGetListActionRequest request,
    CancellationToken cancellationToken)
  {
    return new ValueTask<Result<List<AppIncomingEventPayloadSingleDTO>>>(_service.GetList(request.Query, cancellationToken));
  }
}
