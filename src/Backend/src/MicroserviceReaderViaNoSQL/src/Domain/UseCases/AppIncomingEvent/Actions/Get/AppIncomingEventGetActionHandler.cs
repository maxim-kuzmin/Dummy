namespace Makc.Dummy.MicroserviceReaderViaNoSQL.Domain.UseCases.AppIncomingEvent.Actions.Get;

/// <summary>
/// Обработчик действия по получению входящего события приложения.
/// </summary>
/// <param name="_service">Сервис.</param>
public class AppIncomingEventGetActionHandler(IAppIncomingEventQueryService _service) :
  IQueryHandler<AppIncomingEventGetActionRequest, Result<AppIncomingEventSingleDTO>>
{
  /// <inheritdoc/>
  public async Task<Result<AppIncomingEventSingleDTO>> Handle(
    AppIncomingEventGetActionRequest request,
    CancellationToken cancellationToken)
  {
    var result = await _service.GetSingle(request.Query, cancellationToken).ConfigureAwait(false);

    return result != null ? Result.Success(result) : Result.NotFound();
  }
}
