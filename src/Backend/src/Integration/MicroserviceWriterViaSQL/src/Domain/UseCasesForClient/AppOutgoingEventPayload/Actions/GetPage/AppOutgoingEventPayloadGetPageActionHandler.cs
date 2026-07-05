namespace Makc.Dummy.Integration.MicroserviceWriterViaSQL.Domain.UseCasesForClient.AppOutgoingEventPayload.Actions.GetPage;

/// <summary>
/// Обработчик действия по получению страницы полезных нагрузок исходящего события приложения.
/// </summary>
/// <param name="_service">Сервис.</param>
public class AppOutgoingEventPayloadGetPageActionHandler(IAppOutgoingEventPayloadQueryService _service) :
  IRequestHandler<AppOutgoingEventPayloadGetPageActionRequest, Result<AppOutgoingEventPayloadPageDTO>>
{
  /// <inheritdoc/>
  public ValueTask<Result<AppOutgoingEventPayloadPageDTO>> Handle(
    AppOutgoingEventPayloadGetPageActionRequest request,
    CancellationToken cancellationToken)
  {
    return new ValueTask<Result<AppOutgoingEventPayloadPageDTO>>(_service.GetPage(request.Query, cancellationToken));
  }
}
