namespace Makc.Dummy.MicroserviceReaderViaNoSQL.Domain.UseCases.AppIncomingEventPayload.Actions.GetPage;

/// <summary>
/// Обработчик действия по получению страницы полезных нагрузок входящего события приложения.
/// </summary>
/// <param name="_service">Сервис.</param>
public class AppIncomingEventPayloadGetPageActionHandler(IAppIncomingEventPayloadQueryService _service) :
  IRequestHandler<AppIncomingEventPayloadGetPageActionRequest, Result<AppIncomingEventPayloadPageDTO>>
{
  /// <inheritdoc/>
  public async ValueTask<Result<AppIncomingEventPayloadPageDTO>> Handle(
    AppIncomingEventPayloadGetPageActionRequest request,
    CancellationToken cancellationToken)
  {
    var result = await _service.GetPage(request.Query, cancellationToken).ConfigureAwait(false);

    return Result.Success(result);
  }
}
