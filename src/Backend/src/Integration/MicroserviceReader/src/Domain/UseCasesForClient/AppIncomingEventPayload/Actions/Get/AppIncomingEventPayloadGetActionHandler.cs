namespace Makc.Dummy.Integration.MicroserviceReader.Domain.UseCasesForClient.AppIncomingEventPayload.Actions.Get;

/// <summary>
/// Обработчик действия по получению полезной нагрузки входящего события приложения.
/// </summary>
/// <param name="_service">Сервис.</param>
public class AppIncomingEventPayloadGetActionHandler(IAppIncomingEventPayloadQueryService _service) :
  IQueryHandler<AppIncomingEventPayloadGetActionRequest, Result<AppIncomingEventPayloadSingleDTO>>
{
  /// <inheritdoc/>
  public Task<Result<AppIncomingEventPayloadSingleDTO>> Handle(
    AppIncomingEventPayloadGetActionRequest request,
    CancellationToken cancellationToken)
  {
    return _service.GetSingle(request.Query, cancellationToken);
  }
}
