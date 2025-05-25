namespace Makc.Dummy.Integration.MicroserviceReader.Domain.UseCasesForClient.AppIncomingEvent.Actions.GetPage;

/// <summary>
/// Обработчик действия по получению страницы входящих событий приложения.
/// </summary>
/// <param name="_service">Сервис.</param>
public class AppIncomingEventGetPageActionHandler(IAppIncomingEventQueryService _service) :
  IQueryHandler<AppIncomingEventGetPageActionRequest, Result<AppIncomingEventPageDTO>>
{
  /// <inheritdoc/>
  public Task<Result<AppIncomingEventPageDTO>> Handle(
    AppIncomingEventGetPageActionRequest request,
    CancellationToken cancellationToken)
  {
    return _service.GetPage(request.Query, cancellationToken);
  }
}
