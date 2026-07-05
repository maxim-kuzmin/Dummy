namespace Makc.Dummy.Integration.MicroserviceWriterViaSQL.Domain.UseCasesForClient.AppOutgoingEventPayload.Actions.Get;

/// <summary>
/// Обработчик действия по получению полезной нагрузки исходящего события приложения.
/// </summary>
/// <param name="_service">Сервис.</param>
public class AppOutgoingEventPayloadGetActionHandler(IAppOutgoingEventPayloadQueryService _service) :
  IRequestHandler<AppOutgoingEventPayloadGetActionRequest, Result<AppOutgoingEventPayloadSingleDTO>>
{
  /// <inheritdoc/>
  public ValueTask<Result<AppOutgoingEventPayloadSingleDTO>> Handle(
    AppOutgoingEventPayloadGetActionRequest request,
    CancellationToken cancellationToken)
  {
    return new ValueTask<Result<AppOutgoingEventPayloadSingleDTO>>(_service.GetSingle(request.Query, cancellationToken));
  }
}
