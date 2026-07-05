namespace Makc.Dummy.MicroserviceReaderViaNoSQL.Domain.UseCases.AppIncomingEventPayload.Actions.Get;

/// <summary>
/// Обработчик действия по получению полезной нагрузки входящего события приложения.
/// </summary>
/// <param name="_service">Сервис.</param>
public class AppIncomingEventPayloadGetActionHandler(IAppIncomingEventPayloadQueryService _service) :
  IRequestHandler<AppIncomingEventPayloadGetActionRequest, Result<AppIncomingEventPayloadSingleDTO>>
{
  /// <inheritdoc/>
  public async ValueTask<Result<AppIncomingEventPayloadSingleDTO>> Handle(
    AppIncomingEventPayloadGetActionRequest request,
    CancellationToken cancellationToken)
  {
    var result = await _service.GetSingle(request.Query, cancellationToken).ConfigureAwait(false);

    return result != null ? Result.Success(result) : Result.NotFound();
  }
}
