namespace Makc.Dummy.Writer.DomainUseCases.DummyItem.Actions.GetList;

/// <summary>
/// Обработчик действия по получению списка фиктивных предметов.
/// </summary>
/// <param name="_appDbQueryContext">Контекст запроса базы данных приложения.</param>
/// <param name="_appSession">Сессия приложения.</param>
/// <param name="_logger">Логгер.</param>
/// <param name="_factory">Фабрика.</param>
public class DummyItemGetListActionHandler(
  IAppDbQueryContext _appDbQueryContext,
  AppSession _appSession,
  ILogger<DummyItemGetActionHandler> _logger,
  IDummyItemGetListActionFactory _factory) : IQueryHandler<DummyItemGetListActionQuery, Result<DummyItemListDTO>>
{
  /// <inheritdoc/>
  public async Task<Result<DummyItemListDTO>> Handle(
    DummyItemGetListActionQuery request,
    CancellationToken cancellationToken)
  {
    var userName = _appSession.User.Identity?.Name;

    _logger.LogDebug("User name: {userName}", userName);

    var dbCommandForFilter = _factory.CreateDbCommandForFilter(request);

    var dbCommandForTotalCount = _factory.CreateDbCommandForTotalCount(dbCommandForFilter);

    var taskForTotalCount = _appDbQueryContext.GetListAsync<long>(dbCommandForTotalCount, cancellationToken);

    var dataForTotalCount = await taskForTotalCount.ConfigureAwait(false);

    var totalCount = dataForTotalCount[0];

    List<DummyItemSingleDTO> items;

    if (totalCount > 0)
    {
      var dbCommandForItems = _factory.CreateDbCommandForItems(dbCommandForFilter, request.Page);

      var taskForItems = _appDbQueryContext.GetListAsync<DummyItemSingleDTO>(dbCommandForItems, cancellationToken);

      items = await taskForItems.ConfigureAwait(false);
    }
    else
    {
      items = [];
    }

    DummyItemListDTO dto = new(items, totalCount);

    return Result.Success(dto);
  }
}
