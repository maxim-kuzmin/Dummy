namespace Makc.Dummy.Integration.MicroserviceReaderViaNoSQL.Domain.UseCasesForClient.AppIncomingEventPayload.Actions.GetPage;

/// <summary>
/// Обработчик действия по получению страницы полезных нагрузок входящего события приложения.
/// </summary>
/// <param name="_service">Сервис.</param>
public class AppIncomingEventPayloadGetPageActionHandler(IAppIncomingEventPayloadQueryService _service) :
  IRequestHandler<AppIncomingEventPayloadGetPageActionRequest, Result<AppIncomingEventPayloadPageDTO>>
{
  /// <inheritdoc/>
  public ValueTask<Result<AppIncomingEventPayloadPageDTO>> Handle(
    AppIncomingEventPayloadGetPageActionRequest request,
    CancellationToken cancellationToken)
  {
    return new ValueTask<Result<AppIncomingEventPayloadPageDTO>>(_service.GetPage(request.Query, cancellationToken));
  }
}
