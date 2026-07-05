namespace Makc.Dummy.Integration.MicroserviceReaderViaNoSQL.Domain.UseCasesForClient.AppIncomingEventPayload.Actions.Get;

/// <summary>
/// Обработчик действия по получению полезной нагрузки входящего события приложения.
/// </summary>
/// <param name="_service">Сервис.</param>
public class AppIncomingEventPayloadGetActionHandler(IAppIncomingEventPayloadQueryService _service) :
  IRequestHandler<AppIncomingEventPayloadGetActionRequest, Result<AppIncomingEventPayloadSingleDTO>>
{
  /// <inheritdoc/>
  public ValueTask<Result<AppIncomingEventPayloadSingleDTO>> Handle(
    AppIncomingEventPayloadGetActionRequest request,
    CancellationToken cancellationToken)
  {
    return new ValueTask<Result<AppIncomingEventPayloadSingleDTO>>(_service.GetSingle(request.Query, cancellationToken));
  }
}
