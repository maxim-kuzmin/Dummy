using Makc.Dummy.MicroserviceWriter.DomainUseCases.AppOutgoingEvent.Query.Sections;

namespace Makc.Dummy.MicroserviceWriter.Infrastructure.MSSQLServer.AppOutgoingEvent.Db.Factories;

/// <summary>
/// Фабрика команд базы данных полезной нагрузки исходящего события приложения.
/// </summary>
/// <param name="_appDbSettings">Настройки базы данных приложения.</param>
/// <param name="_appDbSQLCommandHelper">Помощник для построения команд базы данных SQL.</param>
public class AppOutgoingEventDbCommandFactory(
  AppDbSettings _appDbSettings,
  IAppDbSQLCommandHelper _appDbSQLCommandHelper) : IAppOutgoingEventDbSQLCommandFactory
{
  /// <inheritdoc/>
  public DbSQLCommand CreateDbCommand(AppOutgoingEventSingleQuery query)
  {
    DbSQLCommand result = new();

    var sAppOutgoingEvent = _appDbSettings.Entities.AppOutgoingEvent;

    result.TextBuilder.Append($$"""
select
  "{{sAppOutgoingEvent.ColumnForId}}" "Id",
  "{{sAppOutgoingEvent.ColumnForCreatedAt}}" "CreatedAt",
  "{{sAppOutgoingEvent.ColumnForName}}" "Name",
  "{{sAppOutgoingEvent.ColumnForPublishedAt}}" "PublishedAt"
from
  "{{sAppOutgoingEvent.Schema}}"."{{sAppOutgoingEvent.Table}}"
where
  "{{sAppOutgoingEvent.ColumnForId}}" = @Id
""");

    result.AddParameter("@Id", query.Id);

    return result;
  }

  /// <inheritdoc/>
  public DbSQLCommand CreateDbCommand(AppOutgoingEventUnpublishedListQuery query)
  {
    DbSQLCommand result = new();

    var sAppOutgoingEvent = _appDbSettings.Entities.AppOutgoingEvent;

    string maxCountQuery = query.MaxCount > 0 ? $" top {query.MaxCount}" : string.Empty;

    result.TextBuilder.AppendLine($$"""
select{{maxCountQuery}}
  "{{sAppOutgoingEvent.ColumnForId}}" "Id"
from
  "{{sAppOutgoingEvent.Schema}}"."{{sAppOutgoingEvent.Table}}"
where
  "{{sAppOutgoingEvent.ColumnForPublishedAt}}" is null
""");

    if (query.Ids.Count > 0)
    {
      List<string> parameterNames = new(query.Ids.Count);

      int index = 0;

      foreach (var id in query.Ids)
      {
        string parameterName = $"@Id{index++}";

        parameterNames.Add(parameterName);

        result.AddParameter(parameterName, id);
      }

      string ids = string.Join(",", parameterNames);

      result.TextBuilder.AppendLine($$"""
  and
  "{{sAppOutgoingEvent.ColumnForId}}" in ({{ids}})
""");
    }

    result.TextBuilder.AppendLine($$"""
order by
  "{{sAppOutgoingEvent.ColumnForId}}" asc
""");

    return result;
  }

  /// <inheritdoc/>
  public DbSQLCommand CreateDbCommandForFilter(AppOutgoingEventQueryFilterSection? filter)
  {
    DbSQLCommand result = new();

    if (!string.IsNullOrEmpty(filter?.FullTextSearchQuery))
    {
      var sAppOutgoingEvent = _appDbSettings.Entities.AppOutgoingEvent;

      result.TextBuilder.AppendLine($$"""
where
  ae."{{sAppOutgoingEvent.ColumnForId}}" like @FullTextSearchQuery
  or
  ae."{{sAppOutgoingEvent.ColumnForName}}" like @FullTextSearchQuery
""");

      result.AddParameter("@FullTextSearchQuery", $"%{filter.FullTextSearchQuery}%");
    }

    return result;
  }

  /// <inheritdoc/>
  public DbSQLCommand CreateDbCommandForItems(
    DbSQLCommand dbCommandForFilter,
    QuerySortSection? sort,
    QueryPageSection? page = null)
  {
    DbSQLCommand result = new();

    dbCommandForFilter.CopyParametersTo(result);

    var sAppOutgoingEvent = _appDbSettings.Entities.AppOutgoingEvent;

    result.TextBuilder.AppendLine($$"""
select
  ae."{{sAppOutgoingEvent.ColumnForId}}" "Id",
  ae."{{sAppOutgoingEvent.ColumnForCreatedAt}}" "CreatedAt",  
  ae."{{sAppOutgoingEvent.ColumnForName}}" "Name",
  ae."{{sAppOutgoingEvent.ColumnForPublishedAt}}" "PublishedAt"
from
  "{{sAppOutgoingEvent.Schema}}"."{{sAppOutgoingEvent.Table}}" ae
""");

    result.TextBuilder.AppendLine(dbCommandForFilter.ToString());

    _appDbSQLCommandHelper.AddSorting(result, sort, DummyItemSettings.DefaultQuerySortSection, CreateOrderByField);

    _appDbSQLCommandHelper.AddPagination(result, page);

    return result;
  }

  /// <inheritdoc/>
  public DbSQLCommand CreateDbCommandForTotalCount(DbSQLCommand dbCommandForFilter)
  {
    DbSQLCommand result = new();

    dbCommandForFilter.CopyParametersTo(result);

    var sAppOutgoingEvent = _appDbSettings.Entities.AppOutgoingEvent;

    result.TextBuilder.AppendLine($$"""
select
  count_big(*)
from
  "{{sAppOutgoingEvent.Schema}}"."{{sAppOutgoingEvent.Table}}" ae
""");

    result.TextBuilder.AppendLine(dbCommandForFilter.ToString());

    return result;
  }

  private string CreateOrderByField(string field)
  {
    string result;

    var sAppOutgoingEvent = _appDbSettings.Entities.AppOutgoingEvent;

    if (field.EqualsToSortField(AppOutgoingEventSettings.SortFieldForId))
    {
      result = $""" ae."{sAppOutgoingEvent.ColumnForId}" """;
    }
    else if (field.EqualsToSortField(AppOutgoingEventSettings.SortFieldForName))
    {
      result = $""" ae."{sAppOutgoingEvent.ColumnForName}" """;
    }
    else
    {
      throw new NotImplementedException();
    }

    return result;
  }
}
