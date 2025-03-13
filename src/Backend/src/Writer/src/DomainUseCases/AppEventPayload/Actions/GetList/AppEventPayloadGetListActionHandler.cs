namespace Makc.Dummy.Writer.DomainUseCases.AppEventPayload.Actions.GetList;

/// <summary>
/// Обработчик действия по получению списка полезных нагрузок события приложения.
/// </summary>
/// <param name="_service">Сервис.</param>
public class AppEventPayloadGetListActionHandler(IAppEventPayloadQueryService _service) :
  IQueryHandler<AppEventPayloadGetListActionQuery, Result<AppEventPayloadListDTO>>
{
  /// <inheritdoc/>
  public async Task<Result<AppEventPayloadListDTO>> Handle(
    AppEventPayloadGetListActionQuery request,
    CancellationToken cancellationToken)
  {
    var totalCount = await _service.CountAsync(request.PageQuery, cancellationToken).ConfigureAwait(false);

    List<AppEventPayloadSingleDTO> items;

    if (totalCount > 0)
    {
      items = await _service.ListAsync(request, cancellationToken).ConfigureAwait(false);
    }
    else
    {
      items = [];
    }

    AppEventPayloadListDTO dto = new(items, totalCount);

    return Result.Success(dto);
  }
}
