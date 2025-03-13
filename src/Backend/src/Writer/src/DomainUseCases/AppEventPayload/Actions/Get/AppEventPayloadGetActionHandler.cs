namespace Makc.Dummy.Writer.DomainUseCases.AppEventPayload.Actions.Get;

/// <summary>
/// Обработчик действия по получению полезной нагрузки события приложения.
/// </summary>
/// <param name="_service">Сервис.</param>
public class AppEventPayloadGetActionHandler(IAppEventPayloadQueryService _service) :
  IQueryHandler<AppEventPayloadGetActionQuery, Result<AppEventPayloadSingleDTO>>
{
  /// <inheritdoc/>
  public async Task<Result<AppEventPayloadSingleDTO>> Handle(
    AppEventPayloadGetActionQuery request,
    CancellationToken cancellationToken)
  {
    var dto = await _service.GetAsync(request, cancellationToken).ConfigureAwait(false);

    return dto != null ? Result.Success(dto) : Result.NotFound();
  }
}
