namespace Makc.Dummy.Integration.MicroserviceReader.Domain.UseCasesForClient.AppIncomingEventPayload.Actions.GetPage;

/// <summary>
/// Обработчик действия по получению страницы полезных нагрузок входящего события приложения.
/// </summary>
/// <param name="_service">Сервис.</param>
public class AppIncomingEventPayloadGetPageActionHandler(IAppIncomingEventPayloadQueryService _service) :
  IQueryHandler<AppIncomingEventPayloadGetPageActionRequest, Result<AppIncomingEventPayloadPageDTO>>
{
  /// <inheritdoc/>
  public Task<Result<AppIncomingEventPayloadPageDTO>> Handle(
    AppIncomingEventPayloadGetPageActionRequest request,
    CancellationToken cancellationToken)
  {
    return _service.GetPage(request.Query, cancellationToken);
  }
}
