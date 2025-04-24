namespace Makc.Dummy.Writer.DomainUseCases.AppOutgoingEventPayload.Actions.GetList;

/// <summary>
/// Обработчик действия по получению списка полезных нагрузок исходящего события приложения.
/// </summary>
/// <param name="_service">Сервис.</param>
public class AppOutgoingEventPayloadGetListActionHandler(IAppOutgoingEventPayloadQueryService _service) :
  IQueryHandler<AppOutgoingEventPayloadGetListActionQuery, Result<AppOutgoingEventPayloadListDTO>>
{
  /// <inheritdoc/>
  public async Task<Result<AppOutgoingEventPayloadListDTO>> Handle(
    AppOutgoingEventPayloadGetListActionQuery request,
    CancellationToken cancellationToken)
  {
    var totalCount = await _service.CountAsync(request.PageQuery, cancellationToken).ConfigureAwait(false);

    List<AppOutgoingEventPayloadSingleDTO> items;

    if (totalCount > 0)
    {
      items = await _service.ListAsync(request, cancellationToken).ConfigureAwait(false);
    }
    else
    {
      items = [];
    }

    AppOutgoingEventPayloadListDTO dto = new(items, totalCount);

    return Result.Success(dto);
  }
}
