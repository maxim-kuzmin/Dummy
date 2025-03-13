namespace Makc.Dummy.Writer.DomainUseCases.AppEvent.Actions.Get;

/// <summary>
/// Обработчик действия по получению события приложения.
/// </summary>
/// <param name="_service">Сервис.</param>
public class AppEventGetActionHandler(IAppEventQueryService _service) :
  IQueryHandler<AppEventGetActionQuery, Result<AppEventSingleDTO>>
{
  /// <inheritdoc/>
  public async Task<Result<AppEventSingleDTO>> Handle(
    AppEventGetActionQuery request,
    CancellationToken cancellationToken)
  {
    var dto = await _service.GetAsync(request, cancellationToken).ConfigureAwait(false);

    return dto != null ? Result.Success(dto) : Result.NotFound();
  }
}
