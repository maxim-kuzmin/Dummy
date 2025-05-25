namespace Makc.Dummy.Integration.MicroserviceWriter.Domain.UseCasesForClient.AppOutgoingEventPayload.Actions.GetPage;

/// <summary>
/// Обработчик действия по получению страницы полезных нагрузок исходящего события приложения.
/// </summary>
/// <param name="_service">Сервис.</param>
public class AppOutgoingEventPayloadGetPageActionHandler(IAppOutgoingEventPayloadQueryService _service) :
  IQueryHandler<AppOutgoingEventPayloadGetPageActionRequest, Result<AppOutgoingEventPayloadPageDTO>>
{
  /// <inheritdoc/>
  public Task<Result<AppOutgoingEventPayloadPageDTO>> Handle(
    AppOutgoingEventPayloadGetPageActionRequest request,
    CancellationToken cancellationToken)
  {
    return _service.GetPage(request.Query, cancellationToken);
  }
}
