namespace Makc.Dummy.Reader.DomainUseCases.AppIncomingEventPayload.Actions.GetList;

/// <summary>
/// Обработчик действия по получению списка полезных нагрузок входящего события приложения.
/// </summary>
/// <param name="_service">Сервис.</param>
public class AppIncomingEventPayloadGetListActionHandler(IAppIncomingEventPayloadQueryService _service) :
  IQueryHandler<AppIncomingEventPayloadGetListActionQuery, Result<AppIncomingEventPayloadListDTO>>
{
  /// <inheritdoc/>
  public async Task<Result<AppIncomingEventPayloadListDTO>> Handle(
    AppIncomingEventPayloadGetListActionQuery request,
    CancellationToken cancellationToken)
  {
    var totalCount = await _service.GetCount(request.PageQuery, cancellationToken).ConfigureAwait(false);

    List<AppIncomingEventPayloadSingleDTO> items;

    if (totalCount > 0)
    {
      items = await _service.GetList(request, cancellationToken).ConfigureAwait(false);
    }
    else
    {
      items = [];
    }

    AppIncomingEventPayloadListDTO dto = new(items, totalCount);

    return Result.Success(dto);
  }
}
