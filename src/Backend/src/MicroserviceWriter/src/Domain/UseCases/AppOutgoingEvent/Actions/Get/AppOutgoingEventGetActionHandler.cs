namespace Makc.Dummy.MicroserviceWriter.Domain.UseCases.AppOutgoingEvent.Actions.Get;

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
    var result = await _service.GetSingle(request.Query, cancellationToken).ConfigureAwait(false);

    return result != null ? Result.Success(result) : Result.NotFound();
  }
}
