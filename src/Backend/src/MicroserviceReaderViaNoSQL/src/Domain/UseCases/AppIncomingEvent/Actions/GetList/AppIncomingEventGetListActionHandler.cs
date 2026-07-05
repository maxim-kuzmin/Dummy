namespace Makc.Dummy.MicroserviceReaderViaNoSQL.Domain.UseCases.AppIncomingEvent.Actions.GetList;

/// <summary>
/// Обработчик действия по получению списка входящих событий приложения.
/// </summary>
/// <param name="_service">Сервис.</param>
public class AppIncomingEventGetListActionHandler(IAppIncomingEventQueryService _service) :
  IRequestHandler<AppIncomingEventGetListActionRequest, Result<List<AppIncomingEventSingleDTO>>>
{
  /// <inheritdoc/>
  public async ValueTask<Result<List<AppIncomingEventSingleDTO>>> Handle(
    AppIncomingEventGetListActionRequest request,
    CancellationToken cancellationToken)
  {
    var result = await _service.GetList(request.Query, cancellationToken).ConfigureAwait(false);

    return Result.Success(result);
  }
}
