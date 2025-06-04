namespace Makc.Dummy.MicroserviceWriterViaSQL.Domain.UseCases.AppOutgoingEventPayload.Actions.GetList;

/// <summary>
/// Обработчик действия по получению списка полезных нагрузок исходящего события приложения.
/// </summary>
/// <param name="_service">Сервис.</param>
public class AppOutgoingEventPayloadGetListActionHandler(IAppOutgoingEventPayloadQueryService _service) :
  IQueryHandler<AppOutgoingEventPayloadGetListActionRequest, Result<List<AppOutgoingEventPayloadSingleDTO>>>
{
  /// <inheritdoc/>
  public async Task<Result<List<AppOutgoingEventPayloadSingleDTO>>> Handle(
    AppOutgoingEventPayloadGetListActionRequest request,
    CancellationToken cancellationToken)
  {
    var result = await _service.GetList(request.Query, cancellationToken).ConfigureAwait(false);

    return Result.Success(result);
  }
}
