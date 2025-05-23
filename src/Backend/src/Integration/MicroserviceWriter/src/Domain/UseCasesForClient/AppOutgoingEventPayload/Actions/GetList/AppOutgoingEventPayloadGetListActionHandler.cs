namespace Makc.Dummy.Integration.MicroserviceWriter.Domain.UseCasesForClient.AppOutgoingEventPayload.Actions.GetList;

/// <summary>
/// Обработчик действия по получению списка полезных нагрузок исходящего события приложения.
/// </summary>
/// <param name="_service">Сервис.</param>
public class AppOutgoingEventPayloadGetListActionHandler(IAppOutgoingEventPayloadQueryService _service) :
  IQueryHandler<AppOutgoingEventPayloadGetListActionRequest, Result<AppOutgoingEventPayloadPageDTO>>
{
  /// <inheritdoc/>
  public Task<Result<AppOutgoingEventPayloadPageDTO>> Handle(
    AppOutgoingEventPayloadGetListActionRequest request,
    CancellationToken cancellationToken)
  {
    return _service.GetPage(request.Query, cancellationToken);
  }
}
