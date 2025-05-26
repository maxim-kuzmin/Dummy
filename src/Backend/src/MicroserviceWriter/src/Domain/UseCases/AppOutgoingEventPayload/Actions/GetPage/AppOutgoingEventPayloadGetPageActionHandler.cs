namespace Makc.Dummy.MicroserviceWriter.Domain.UseCases.AppOutgoingEventPayload.Actions.GetPage;

/// <summary>
/// Обработчик действия по получению страницы полезных нагрузок исходящего события приложения.
/// </summary>
/// <param name="_service">Сервис.</param>
public class AppOutgoingEventPayloadGetPageActionHandler(IAppOutgoingEventPayloadQueryService _service) :
  IQueryHandler<AppOutgoingEventPayloadGetPageActionRequest, Result<AppOutgoingEventPayloadPageDTO>>
{
  /// <inheritdoc/>
  public async Task<Result<AppOutgoingEventPayloadPageDTO>> Handle(
    AppOutgoingEventPayloadGetPageActionRequest request,
    CancellationToken cancellationToken)
  {
    var result = await _service.GetPage(request.Query, cancellationToken);

    return Result.Success(result);
  }
}
