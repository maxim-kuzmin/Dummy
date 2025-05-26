namespace Makc.Dummy.MicroserviceWriter.Infrastructure.PostgreSQL.AppOutgoingEvent.Db.Factories;

/// <summary>
/// Фабрика команд базы данных исходящего события приложения.
/// </summary>
/// <param name="_appDbSettings">Настройки базы данных приложения.</param>
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
  "{{sAppOutgoingEvent.ColumnForConcurrencyToken}}" "ConcurrencyToken",
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

    result.TextBuilder.AppendLine($$"""
select
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

    if (query.MaxCount > 0)
    {
      result.TextBuilder.AppendLine($$"""
limit {{query.MaxCount}}
""");
    }

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
  ae."{{sAppOutgoingEvent.ColumnForId}}"::text ilike @FullTextSearchQuery
  or
  ae."{{sAppOutgoingEvent.ColumnForName}}" ilike @FullTextSearchQuery
""");

      result.AddParameter("@FullTextSearchQuery", $"%{filter.FullTextSearchQuery}%");
    }

    return result;
  }

  /// <inheritdoc/>
  public DbSQLCommand CreateDbCommandForItems(
    DbSQLCommand dbCommandForFilter,
    QuerySortSection? sort,
    int maxCount)
  {
    string maxCountQuery = _appDbSQLCommandHelper.GetMaxCountQuery(maxCount);

    return CreateDbCommandForItems(dbCommandForFilter, sort, maxCountQuery);
  }

  /// <inheritdoc/>
  public DbSQLCommand CreateDbCommandForItems(
    DbSQLCommand dbCommandForFilter,
    QuerySortSection? sort,
    QueryPageSection? page)
  {
    var result = CreateDbCommandForItems(dbCommandForFilter, sort);

    _appDbSQLCommandHelper.AddPagination(result, page);

    return result;
  }

  /// <inheritdoc/>
  public DbSQLCommand CreateDbCommandForItems(
    DbSQLCommand dbCommandForFilter,    
    QuerySortSection? sort,
    string maxCountQuery = "")
  {
    DbSQLCommand result = new();

    dbCommandForFilter.CopyParametersTo(result);

    var sAppOutgoingEvent = _appDbSettings.Entities.AppOutgoingEvent;

    result.TextBuilder.AppendLine($$"""
select
  ae."{{sAppOutgoingEvent.ColumnForId}}" "Id",
  ae."{{sAppOutgoingEvent.ColumnForConcurrencyToken}}" "ConcurrencyToken",
  ae."{{sAppOutgoingEvent.ColumnForCreatedAt}}" "CreatedAt",
  ae."{{sAppOutgoingEvent.ColumnForName}}" "Name",
  ae."{{sAppOutgoingEvent.ColumnForPublishedAt}}" "PublishedAt"
from
  "{{sAppOutgoingEvent.Schema}}"."{{sAppOutgoingEvent.Table}}" ae
""");

    result.TextBuilder.AppendLine(dbCommandForFilter.ToString());

    _appDbSQLCommandHelper.AddSorting(
      result,
      sort,
      AppOutgoingEventSettings.DefaultQuerySortSection,
      CreateOrderByField);

    if (!string.IsNullOrWhiteSpace(maxCountQuery))
    {
      result.TextBuilder.Append(maxCountQuery);
    }
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
  count(*)
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
