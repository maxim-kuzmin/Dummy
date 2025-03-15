﻿namespace Makc.Dummy.Writer.Infrastructure.MSSQLServer.AppEventPayload.Db.Command;

/// <summary>
/// Фабрика команд базы данных полезной нагрузки события приложения.
/// </summary>
/// <param name="_appDbSettings">Настройки базы данных приложения.</param>
/// <param name="_dbHelper">Помощник базы данных.</param>
public class AppEventPayloadDbCommandFactory(
  AppDbSettings _appDbSettings,
  IDbSQLHelper _dbHelper) : IAppEventPayloadDbSQLCommandFactory
{
  /// <inheritdoc/>
  public DbSQLCommand CreateDbCommand(AppEventPayloadSingleQuery query)
  {
    DbSQLCommand result = new();

    var sAppEventPayload = _appDbSettings.Entities.AppEventPayload;

    result.TextBuilder.Append($$"""
select
  "{{sAppEventPayload.ColumnForId}}" "Id",
  "{{sAppEventPayload.ColumnForAppEventId}}" "AppEventId",
  "{{sAppEventPayload.ColumnForData}}" "Data"
from
  "{{sAppEventPayload.Schema}}"."{{sAppEventPayload.Table}}"
where
  "{{sAppEventPayload.ColumnForId}}" = @Id
""");

    result.AddParameter("@Id", query.Id);

    return result;
  }

  /// <inheritdoc/>
  public DbSQLCommand CreateDbCommandForFilter(AppEventPayloadPageQuery query)
  {
    DbSQLCommand result = new();

    var filter = query.Filter;

    if (!string.IsNullOrEmpty(filter?.FullTextSearchQuery))
    {
      var sAppEventPayload = _appDbSettings.Entities.AppEventPayload;

      result.TextBuilder.AppendLine($$"""
where
  aep."{{sAppEventPayload.ColumnForId}}" like @FullTextSearchQuery
  or
  aep."{{sAppEventPayload.ColumnForData}}" like @FullTextSearchQuery
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

    var sAppEventPayload = _appDbSettings.Entities.AppEventPayload;

    result.TextBuilder.AppendLine($$"""
select
  aep."{{sAppEventPayload.ColumnForId}}" "Id",
  aep."{{sAppEventPayload.ColumnForAppEventId}}" "AppEventId",
  aep."{{sAppEventPayload.ColumnForData}}" "Data"
from
  "{{sAppEventPayload.Schema}}"."{{sAppEventPayload.Table}}" aep
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

    var sAppEventPayload = _appDbSettings.Entities.AppEventPayload;

    result.TextBuilder.AppendLine($$""" 
select
  count_big(*)
from
  "{{sAppEventPayload.Schema}}"."{{sAppEventPayload.Table}}"
""");

    result.TextBuilder.AppendLine(dbCommandForFilter.ToString());

    return result;
  }

  private string CreateOrderByField(string field)
  {
    string result;

    var sAppEventPayload = _appDbSettings.Entities.AppEventPayload;

    if (field.EqualsToSortField(AppEventPayloadSettings.SortFieldForAppEventId))
    {
      result = $""" aep."{sAppEventPayload.ColumnForAppEventId}" """;
    }
    else if (field.EqualsToSortField(AppEventPayloadSettings.SortFieldForData))
    {
      result = $""" aep."{sAppEventPayload.ColumnForData}" """;
    }
    else if (field.EqualsToSortField(AppEventPayloadSettings.SortFieldForId))
    {
      result = $""" aep."{sAppEventPayload.ColumnForId}" """;
    }
    else
    {
      throw new NotImplementedException();
    }

    return result;
  }
}
