namespace Makc.Dummy.Integration.MicroserviceReaderViaNoSQL.Domain.UseCasesForClient.AppIncomingEvent.Actions.GetPage;

/// <summary>
/// Обработчик действия по получению страницы входящих событий приложения.
/// </summary>
/// <param name="_service">Сервис.</param>
public class AppIncomingEventGetPageActionHandler(IAppIncomingEventQueryService _service) :
  IRequestHandler<AppIncomingEventGetPageActionRequest, Result<AppIncomingEventPageDTO>>
{
  /// <inheritdoc/>
  public ValueTask<Result<AppIncomingEventPageDTO>> Handle(
    AppIncomingEventGetPageActionRequest request,
    CancellationToken cancellationToken)
  {
    return new ValueTask<Result<AppIncomingEventPageDTO>>(_service.GetPage(request.Query, cancellationToken));
  }
}
