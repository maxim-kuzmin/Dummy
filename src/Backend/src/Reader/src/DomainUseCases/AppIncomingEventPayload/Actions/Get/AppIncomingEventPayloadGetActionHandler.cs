namespace Makc.Dummy.Reader.DomainUseCases.AppIncomingEventPayload.Actions.Get;

/// <summary>
/// Обработчик действия по получению полезной нагрузки входящего события приложения.
/// </summary>
/// <param name="_service">Сервис.</param>
public class AppIncomingEventPayloadGetActionHandler(IAppIncomingEventPayloadQueryService _service) :
  IQueryHandler<AppIncomingEventPayloadGetActionQuery, Result<AppIncomingEventPayloadSingleDTO>>
{
  /// <inheritdoc/>
  public async Task<Result<AppIncomingEventPayloadSingleDTO>> Handle(
    AppIncomingEventPayloadGetActionQuery request,
    CancellationToken cancellationToken)
  {
    var dto = await _service.GetAsync(request, cancellationToken).ConfigureAwait(false);

    return dto != null ? Result.Success(dto) : Result.NotFound();
  }
}
