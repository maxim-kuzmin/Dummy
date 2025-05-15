namespace Makc.Dummy.MicroserviceReader.DomainUseCases.AppIncomingEvent.Actions.Get;

/// <summary>
/// Обработчик действия по получению входящего события приложения.
/// </summary>
/// <param name="_service">Сервис.</param>
public class AppIncomingEventGetActionHandler(IAppIncomingEventQueryService _service) :
  IQueryHandler<AppIncomingEventGetActionQuery, Result<AppIncomingEventSingleDTO>>
{
  /// <inheritdoc/>
  public async Task<Result<AppIncomingEventSingleDTO>> Handle(
    AppIncomingEventGetActionQuery request,
    CancellationToken cancellationToken)
  {
    var dto = await _service.GetSingle(request, cancellationToken).ConfigureAwait(false);

    return dto != null ? Result.Success(dto) : Result.NotFound();
  }
}
