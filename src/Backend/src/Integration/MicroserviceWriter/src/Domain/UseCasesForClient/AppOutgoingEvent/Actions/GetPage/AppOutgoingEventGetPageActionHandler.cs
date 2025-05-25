namespace Makc.Dummy.Integration.MicroserviceWriter.Domain.UseCasesForClient.AppOutgoingEvent.Actions.GetPage;

/// <summary>
/// Обработчик действия по получению страницы исходящих событий приложения.
/// </summary>
/// <param name="_service">Сервис.</param>
public class AppOutgoingEventGetPageActionHandler(IAppOutgoingEventQueryService _service) :
  IQueryHandler<AppOutgoingEventGetPageActionRequest, Result<AppOutgoingEventPageDTO>>
{
  /// <inheritdoc/>
  public Task<Result<AppOutgoingEventPageDTO>> Handle(
    AppOutgoingEventGetPageActionRequest request,
    CancellationToken cancellationToken)
  {
    return _service.GetPage(request.Query, cancellationToken);
  }
}
