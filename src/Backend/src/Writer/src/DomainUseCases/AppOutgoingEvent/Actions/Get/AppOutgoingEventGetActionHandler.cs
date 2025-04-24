namespace Makc.Dummy.Writer.DomainUseCases.AppOutgoingEvent.Actions.Get;

/// <summary>
/// Обработчик действия по получению исходящего события приложения.
/// </summary>
/// <param name="_service">Сервис.</param>
public class AppOutgoingEventGetActionHandler(IAppOutgoingEventQueryService _service) :
  IQueryHandler<AppOutgoingEventGetActionQuery, Result<AppOutgoingEventSingleDTO>>
{
  /// <inheritdoc/>
  public async Task<Result<AppOutgoingEventSingleDTO>> Handle(
    AppOutgoingEventGetActionQuery request,
    CancellationToken cancellationToken)
  {
    var dto = await _service.GetAsync(request, cancellationToken).ConfigureAwait(false);

    return dto != null ? Result.Success(dto) : Result.NotFound();
  }
}
