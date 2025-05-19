namespace Makc.Dummy.MicroserviceReader.DomainUseCases.AppIncomingEventPayload.Actions.GetList;

/// <summary>
/// Обработчик действия по получению списка полезных нагрузок входящего события приложения.
/// </summary>
/// <param name="_service">Сервис.</param>
public class AppIncomingEventPayloadGetListActionHandler(IAppIncomingEventPayloadQueryService _service) :
  IQueryHandler<AppIncomingEventPayloadGetListActionRequest, Result<AppIncomingEventPayloadListDTO>>
{
  /// <inheritdoc/>
  public async Task<Result<AppIncomingEventPayloadListDTO>> Handle(
    AppIncomingEventPayloadGetListActionRequest request,
    CancellationToken cancellationToken)
  {
    var result = await _service.GetPage(request.Query, cancellationToken);

    return Result.Success(result);
  }
}
