namespace Makc.Dummy.MicroserviceWriter.DomainUseCases.AppOutgoingEvent.Actions.Get;

/// <summary>
/// Обработчик действия по получению исходящего события приложения.
/// </summary>
/// <param name="_service">Сервис.</param>
public class AppOutgoingEventGetActionHandler(IAppOutgoingEventQueryService _service) :
  IQueryHandler<AppOutgoingEventGetActionRequest, Result<AppOutgoingEventSingleDTO>>
{
  /// <inheritdoc/>
  public async Task<Result<AppOutgoingEventSingleDTO>> Handle(
    AppOutgoingEventGetActionRequest request,
    CancellationToken cancellationToken)
  {
    var dto = await _service.GetSingle(request.Query, cancellationToken).ConfigureAwait(false);

    return dto != null ? Result.Success(dto) : Result.NotFound();
  }
}
