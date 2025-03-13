namespace Makc.Dummy.Writer.DomainUseCases.AppEvent.Actions.GetList;

/// <summary>
/// Обработчик действия по получению списка событий приложения.
/// </summary>
/// <param name="_service">Сервис.</param>
public class AppEventGetListActionHandler(IAppEventQueryService _service) :
  IQueryHandler<AppEventGetListActionQuery, Result<AppEventListDTO>>
{
  /// <inheritdoc/>
  public async Task<Result<AppEventListDTO>> Handle(
    AppEventGetListActionQuery request,
    CancellationToken cancellationToken)
  {
    var totalCount = await _service.CountAsync(request.PageQuery, cancellationToken).ConfigureAwait(false);

    List<AppEventSingleDTO> items;

    if (totalCount > 0)
    {
      items = await _service.ListAsync(request, cancellationToken).ConfigureAwait(false);
    }
    else
    {
      items = [];
    }

    AppEventListDTO dto = new(items, totalCount);

    return Result.Success(dto);
  }
}
