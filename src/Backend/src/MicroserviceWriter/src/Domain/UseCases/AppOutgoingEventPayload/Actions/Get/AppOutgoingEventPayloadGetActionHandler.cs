namespace Makc.Dummy.MicroserviceWriter.Domain.UseCases.AppOutgoingEventPayload.Actions.Get;

/// <summary>
/// Обработчик действия по получению полезной нагрузки исходящего события приложения.
/// </summary>
/// <param name="_service">Сервис.</param>
public class AppOutgoingEventPayloadGetActionHandler(IAppOutgoingEventPayloadQueryService _service) :
  IQueryHandler<AppOutgoingEventPayloadGetActionRequest, Result<AppOutgoingEventPayloadSingleDTO>>
{
  /// <inheritdoc/>
  public async Task<Result<AppOutgoingEventPayloadSingleDTO>> Handle(
    AppOutgoingEventPayloadGetActionRequest request,
    CancellationToken cancellationToken)
  {
    var result = await _service.GetSingle(request.Query, cancellationToken).ConfigureAwait(false);

    return result != null ? Result.Success(result) : Result.NotFound();
  }
}
