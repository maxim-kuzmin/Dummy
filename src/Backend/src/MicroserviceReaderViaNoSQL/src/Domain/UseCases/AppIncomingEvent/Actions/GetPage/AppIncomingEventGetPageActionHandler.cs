namespace Makc.Dummy.MicroserviceReaderViaNoSQL.Domain.UseCases.AppIncomingEvent.Actions.GetPage;

/// <summary>
/// Обработчик действия по получению страницы входящих событий приложения.
/// </summary>
/// <param name="_service">Сервис.</param>
public class AppIncomingEventGetPageActionHandler(IAppIncomingEventQueryService _service) :
  IQueryHandler<AppIncomingEventGetPageActionRequest, Result<AppIncomingEventPageDTO>>
{
  /// <inheritdoc/>
  public async Task<Result<AppIncomingEventPageDTO>> Handle(
    AppIncomingEventGetPageActionRequest request,
    CancellationToken cancellationToken)
  {
    var result = await _service.GetPage(request.Query, cancellationToken).ConfigureAwait(false);

    return Result.Success(result);
  }
}
