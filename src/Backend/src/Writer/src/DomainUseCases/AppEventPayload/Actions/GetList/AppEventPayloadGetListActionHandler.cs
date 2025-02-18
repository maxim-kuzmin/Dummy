namespace Makc.Dummy.Writer.DomainUseCases.AppEventPayload.Actions.GetList;

/// <summary>
/// Обработчик действия по получению списка полезных нагрузок события приложения.
/// </summary>
/// <param name="_appDbQueryContext">Контекст запроса базы данных приложения.</param>
/// <param name="_factory">Фабрика.</param>
public class AppEventPayloadGetListActionHandler(
  IAppDbQueryContext _appDbQueryContext,
  IAppEventPayloadGetListActionFactory _factory) :
  IQueryHandler<AppEventPayloadGetListActionQuery, Result<AppEventPayloadListDTO>>
{
  /// <inheritdoc/>
  public async Task<Result<AppEventPayloadListDTO>> Handle(
    AppEventPayloadGetListActionQuery request,
    CancellationToken cancellationToken)
  {
    var dbCommandForFilter = _factory.CreateDbCommandForFilter(request);

    var dbCommandForTotalCount = _factory.CreateDbCommandForTotalCount(dbCommandForFilter);

    var taskForTotalCount = _appDbQueryContext.GetListAsync<long>(dbCommandForTotalCount, cancellationToken);

    var dataForTotalCount = await taskForTotalCount.ConfigureAwait(false);

    var totalCount = dataForTotalCount[0];

    List<AppEventPayloadSingleDTO> items;

    if (totalCount > 0)
    {
      var dbCommandForItems = _factory.CreateDbCommandForItems(dbCommandForFilter, request.Page);

      var taskForItems = _appDbQueryContext.GetListAsync<AppEventPayloadSingleDTO>(
        dbCommandForItems,
        cancellationToken);

      items = await taskForItems.ConfigureAwait(false);
    }
    else
    {
      items = [];
    }

    AppEventPayloadListDTO dto = new(items, totalCount);

    return Result.Success(dto);
  }
}
