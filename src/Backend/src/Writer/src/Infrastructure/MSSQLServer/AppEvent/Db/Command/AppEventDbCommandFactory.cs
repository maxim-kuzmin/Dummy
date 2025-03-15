namespace Makc.Dummy.Writer.Infrastructure.MSSQLServer.AppEvent.Db.Command;

/// <summary>
/// Фабрика команд базы данных полезной нагрузки события приложения.
/// </summary>
/// <param name="_appDbSettings">Настройки базы данных приложения.</param>
/// <param name="_dbHelper">Помощник базы данных.</param>
public class AppEventDbCommandFactory(
  AppDbSettings _appDbSettings,
  IDbSQLHelper _dbHelper) : IAppEventDbSQLCommandFactory
{
  /// <inheritdoc/>
  public DbSQLCommand CreateDbCommand(AppEventSingleQuery query)
  {
    DbSQLCommand result = new();

    var sAppEvent = _appDbSettings.Entities.AppEvent;

    result.TextBuilder.Append($$"""
select
  "{{sAppEvent.ColumnForId}}" "Id",
  "{{sAppEvent.ColumnForCreatedAt}}" "CreatedAt",
  "{{sAppEvent.ColumnForIsPublished}}" "IsPublished",
  "{{sAppEvent.ColumnForName}}" "Name"
from
  "{{sAppEvent.Schema}}"."{{sAppEvent.Table}}"
where
  "{{sAppEvent.ColumnForId}}" = @Id
""");

    result.AddParameter("@Id", query.Id);

    return result;
  }

  /// <inheritdoc/>
  public DbSQLCommand CreateDbCommandForFilter(AppEventPageQuery query)
  {
    DbSQLCommand result = new();

    var filter = query.Filter;

    if (!string.IsNullOrEmpty(filter?.FullTextSearchQuery))
    {
      var sAppEvent = _appDbSettings.Entities.AppEvent;

      result.TextBuilder.AppendLine($$"""
where
  ae."{{sAppEvent.ColumnForId}}" like @FullTextSearchQuery
  or
  ae."{{sAppEvent.ColumnForName}}" like @FullTextSearchQuery
""");

      result.AddParameter("@FullTextSearchQuery", $"%{filter.FullTextSearchQuery}%");
    }

    return result;
  }

  /// <inheritdoc/>
  public DbSQLCommand CreateDbCommandForItems(
    DbSQLCommand dbCommandForFilter,
    QueryPageSection? page,
    QuerySortSection? sort)
  {
    DbSQLCommand result = new();

    dbCommandForFilter.CopyParametersTo(result);

    var sAppEvent = _appDbSettings.Entities.AppEvent;

    if (sort == null)
    {
      sort = AppEventSettings.DefaultQuerySortSection;
    }

    var orderByDirection = sort.IsDesc ? "desc" : "asc";

    string orderByField;

    if (sort.Field.EqualsToSortField(AppEventSettings.SortFieldForId))
    {
      orderByField = $""" ae."{sAppEvent.ColumnForId}" """;
    }
    else if (sort.Field.EqualsToSortField(AppEventSettings.SortFieldForName))
    {
      orderByField = $""" ae."{sAppEvent.ColumnForName}" """;
    }
    else
    {
      throw new NotImplementedException();
    }

    result.TextBuilder.AppendLine($$"""
select
  ae."{{sAppEvent.ColumnForId}}" "Id",
  ae."{{sAppEvent.ColumnForCreatedAt}}" "CreatedAt",
  ae."{{sAppEvent.ColumnForIsPublished}}" "IsPublished",
  ae."{{sAppEvent.ColumnForName}}" "Name"
from
  "{{sAppEvent.Schema}}"."{{sAppEvent.Table}}" ae
""");

    result.TextBuilder.AppendLine(dbCommandForFilter.ToString());

    _dbHelper.AddSorting(result, sort, DummyItemSettings.DefaultQuerySortSection, CreateOrderByField);

    _dbHelper.AddPagination(result, page);

    return result;
  }

  /// <inheritdoc/>
  public DbSQLCommand CreateDbCommandForTotalCount(DbSQLCommand dbCommandForFilter)
  {
    DbSQLCommand result = new();

    dbCommandForFilter.CopyParametersTo(result);

    var sAppEvent = _appDbSettings.Entities.AppEvent;

    result.TextBuilder.AppendLine($$"""
select
  count_big(*)
from
  "{{sAppEvent.Schema}}"."{{sAppEvent.Table}}"
""");

    result.TextBuilder.AppendLine(dbCommandForFilter.ToString());

    return result;
  }

  private string CreateOrderByField(string field)
  {
    string result;

    var sAppEvent = _appDbSettings.Entities.AppEvent;

    if (field.EqualsToSortField(AppEventSettings.SortFieldForId))
    {
      result = $""" ae."{sAppEvent.ColumnForId}" """;
    }
    else if (field.EqualsToSortField(AppEventSettings.SortFieldForName))
    {
      result = $""" ae."{sAppEvent.ColumnForName}" """;
    }
    else
    {
      throw new NotImplementedException();
    }

    return result;
  }
}
