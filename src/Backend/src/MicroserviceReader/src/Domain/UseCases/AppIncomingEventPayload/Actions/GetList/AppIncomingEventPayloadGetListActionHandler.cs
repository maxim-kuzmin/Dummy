namespace Makc.Dummy.MicroserviceReader.Domain.UseCases.AppIncomingEventPayload.Actions.GetList;

/// <summary>
/// Обработчик действия по получению списка полезных нагрузок входящего события приложения.
/// </summary>
/// <param name="_service">Сервис.</param>
public class AppIncomingEventPayloadGetListActionHandler(IAppIncomingEventPayloadQueryService _service) :
  IQueryHandler<AppIncomingEventPayloadGetListActionRequest, Result<List<AppIncomingEventPayloadSingleDTO>>>
{
  /// <inheritdoc/>
  public async Task<Result<List<AppIncomingEventPayloadSingleDTO>>> Handle(
    AppIncomingEventPayloadGetListActionRequest request,
    CancellationToken cancellationToken)
  {
    var result = await _service.GetList(request.Query, cancellationToken);

    return Result.Success(result);
  }
}
