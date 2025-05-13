namespace Makc.Dummy.Writer.DomainUseCases.AppOutgoingEventPayload.Actions.Get;

/// <summary>
/// Обработчик действия по получению полезной нагрузки исходящего события приложения.
/// </summary>
/// <param name="_service">Сервис.</param>
public class AppOutgoingEventPayloadGetActionHandler(IAppOutgoingEventPayloadQueryService _service) :
  IQueryHandler<AppOutgoingEventPayloadGetActionQuery, Result<AppOutgoingEventPayloadSingleDTO>>
{
  /// <inheritdoc/>
  public async Task<Result<AppOutgoingEventPayloadSingleDTO>> Handle(
    AppOutgoingEventPayloadGetActionQuery request,
    CancellationToken cancellationToken)
  {
    var dto = await _service.GetSingle(request, cancellationToken).ConfigureAwait(false);

    return dto != null ? Result.Success(dto) : Result.NotFound();
  }
}
