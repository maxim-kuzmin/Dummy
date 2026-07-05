namespace Makc.Dummy.Integration.MicroserviceWriterViaSQL.Domain.UseCasesForClient.AppOutgoingEventPayload.Actions.GetList;

/// <summary>
/// Обработчик действия по получению списка полезных нагрузок исходящего события приложения.
/// </summary>
/// <param name="_service">Сервис.</param>
public class AppOutgoingEventPayloadGetListActionHandler(IAppOutgoingEventPayloadQueryService _service) :
  IRequestHandler<AppOutgoingEventPayloadGetListActionRequest, Result<List<AppOutgoingEventPayloadSingleDTO>>>
{
  /// <inheritdoc/>
  public ValueTask<Result<List<AppOutgoingEventPayloadSingleDTO>>> Handle(
    AppOutgoingEventPayloadGetListActionRequest request,
    CancellationToken cancellationToken)
  {
    return new ValueTask<Result<List<AppOutgoingEventPayloadSingleDTO>>>(_service.GetList(request.Query, cancellationToken));
  }
}
