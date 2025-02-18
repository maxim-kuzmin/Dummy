namespace Makc.Dummy.Writer.DomainUseCases.AppEvent.Actions.GetList;

/// <summary>
/// Обработчик действия по получению списка событий приложения.
/// </summary>
/// <param name="_appDbQueryContext">Контекст запроса базы данных приложения.</param>
/// <param name="_factory">Фабрика.</param>
public class AppEventGetListActionHandler(
  IAppDbQueryContext _appDbQueryContext,
  IAppEventGetListActionFactory _factory) : IQueryHandler<AppEventGetListActionQuery, Result<AppEventListDTO>>
{
  /// <inheritdoc/>
  public async Task<Result<AppEventListDTO>> Handle(
    AppEventGetListActionQuery request,
    CancellationToken cancellationToken)
  {
    var dbCommandForFilter = _factory.CreateDbCommandForFilter(request);

    var dbCommandForTotalCount = _factory.CreateDbCommandForTotalCount(dbCommandForFilter);

    var taskForTotalCount = _appDbQueryContext.GetListAsync<long>(dbCommandForTotalCount, cancellationToken);

    var dataForTotalCount = await taskForTotalCount.ConfigureAwait(false);

    var totalCount = dataForTotalCount[0];

    List<AppEventSingleDTO> items;

    if (totalCount > 0)
    {
      var dbCommandForItems = _factory.CreateDbCommandForItems(dbCommandForFilter, request.Page);

      var taskForItems = _appDbQueryContext.GetListAsync<AppEventSingleDTO>(dbCommandForItems, cancellationToken);

      items = await taskForItems.ConfigureAwait(false);
    }
    else
    {
      items = [];
    }

    AppEventListDTO dto = new(items, totalCount);

    return Result.Success(dto);
  }
}
