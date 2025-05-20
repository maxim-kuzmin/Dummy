namespace Makc.Dummy.MicroserviceReader.Domain.UseCases.AppIncomingEvent.Actions.GetList;

/// <summary>
/// Обработчик действия по получению списка входящих событий приложения.
/// </summary>
/// <param name="_service">Сервис.</param>
public class AppIncomingEventGetListActionHandler(IAppIncomingEventQueryService _service) :
  IQueryHandler<AppIncomingEventGetListActionRequest, Result<AppIncomingEventListDTO>>
{
  /// <inheritdoc/>
  public async Task<Result<AppIncomingEventListDTO>> Handle(
    AppIncomingEventGetListActionRequest request,
    CancellationToken cancellationToken)
  {
    var totalCount = await _service.GetCount(request.Query, cancellationToken).ConfigureAwait(false);

    List<AppIncomingEventSingleDTO> items;

    if (totalCount > 0)
    {
      items = await _service.GetList(request.Query, cancellationToken).ConfigureAwait(false);
    }
    else
    {
      items = [];
    }

    AppIncomingEventListDTO dto = new(items, totalCount);

    return Result.Success(dto);
  }
}
