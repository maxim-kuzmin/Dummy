namespace Makc.Dummy.Integration.MicroserviceWriterViaSQL.Domain.UseCasesForClient.AppOutgoingEvent.Actions.GetPage;

/// <summary>
/// Обработчик действия по получению страницы исходящих событий приложения.
/// </summary>
/// <param name="_service">Сервис.</param>
public class AppOutgoingEventGetPageActionHandler(IAppOutgoingEventQueryService _service) :
  IRequestHandler<AppOutgoingEventGetPageActionRequest, Result<AppOutgoingEventPageDTO>>
{
  /// <inheritdoc/>
  public ValueTask<Result<AppOutgoingEventPageDTO>> Handle(
    AppOutgoingEventGetPageActionRequest request,
    CancellationToken cancellationToken)
  {
    return new ValueTask<Result<AppOutgoingEventPageDTO>>(_service.GetPage(request.Query, cancellationToken));
  }
}
