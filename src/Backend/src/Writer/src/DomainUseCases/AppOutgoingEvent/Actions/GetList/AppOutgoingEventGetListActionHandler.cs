namespace Makc.Dummy.Writer.DomainUseCases.AppOutgoingEvent.Actions.GetList;

/// <summary>
/// Обработчик действия по получению списка исходящих событий приложения.
/// </summary>
/// <param name="_service">Сервис.</param>
public class AppOutgoingEventGetListActionHandler(IAppOutgoingEventQueryService _service) :
  IQueryHandler<AppOutgoingEventGetListActionQuery, Result<AppOutgoingEventListDTO>>
{
  /// <inheritdoc/>
  public async Task<Result<AppOutgoingEventListDTO>> Handle(
    AppOutgoingEventGetListActionQuery request,
    CancellationToken cancellationToken)
  {
    var totalCount = await _service.GetCount(request.PageQuery, cancellationToken).ConfigureAwait(false);

    List<AppOutgoingEventSingleDTO> items;

    if (totalCount > 0)
    {
      items = await _service.GetList(request, cancellationToken).ConfigureAwait(false);
    }
    else
    {
      items = [];
    }

    AppOutgoingEventListDTO dto = new(items, totalCount);

    return Result.Success(dto);
  }
}
