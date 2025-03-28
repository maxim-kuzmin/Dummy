﻿namespace Makc.Dummy.Writer.Infrastructure.PostgreSQL.DummyItem.Db.Factories;

/// <summary>
/// Фабрика команд базы данных фиктивного предмета.
/// </summary>
/// <param name="_appDbSettings">Настройки базы данных приложения.</param>
/// <param name="_appDbSQLCommandHelper">Помощник для построения команд базы данных SQL.</param>
public class DummyItemDbCommandFactory(
  AppDbSettings _appDbSettings,
  IAppDbSQLCommandHelper _appDbSQLCommandHelper) : IDummyItemDbSQLCommandFactory
{
  /// <inheritdoc/>
  public DbSQLCommand CreateDbCommand(DummyItemSingleQuery query)
  {
    DbSQLCommand result = new();

    var sDummyItem = _appDbSettings.Entities.DummyItem;

    result.TextBuilder.Append($$"""
select
  "{{sDummyItem.ColumnForId}}" "Id",
  "{{sDummyItem.ColumnForName}}" "Name",
  "{{sDummyItem.ColumnForConcurrencyToken}}" "ConcurrencyToken"
from
  "{{sDummyItem.Schema}}"."{{sDummyItem.Table}}"
where
  "{{sDummyItem.ColumnForId}}" = @Id
""");

    result.AddParameter("@Id", query.Id);

    return result;
  }

  /// <inheritdoc/>
  public DbSQLCommand CreateDbCommandForFilter(DummyItemPageQuery query)
  {
    DbSQLCommand result = new();

    var filter = query.Filter;

    if (!string.IsNullOrEmpty(filter?.FullTextSearchQuery))
    {
      var sDummyItem = _appDbSettings.Entities.DummyItem;

      result.TextBuilder.AppendLine($$"""
where
  di."{{sDummyItem.ColumnForId}}"::text ilike @FullTextSearchQuery
  or
  di."{{sDummyItem.ColumnForName}}" ilike @FullTextSearchQuery
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

    var sDummyItem = _appDbSettings.Entities.DummyItem;

    result.TextBuilder.AppendLine($$"""
select
  di."{{sDummyItem.ColumnForId}}" "Id",
  di."{{sDummyItem.ColumnForName}}" "Name",
  di."{{sDummyItem.ColumnForConcurrencyToken}}" "ConcurrencyToken"
from
  "{{sDummyItem.Schema}}"."{{sDummyItem.Table}}" di
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

    var sDummyItem = _appDbSettings.Entities.DummyItem;

    result.TextBuilder.AppendLine($$""" 
select
  count(*)
from
  "{{sDummyItem.Schema}}"."{{sDummyItem.Table}}" di
""");

    result.TextBuilder.AppendLine(dbCommandForFilter.ToString());

    return result;
  }

  private string CreateOrderByField(string field)
  {
    string result;

    var sDummyItem = _appDbSettings.Entities.DummyItem;

    if (field.EqualsToSortField(DummyItemSettings.SortFieldForId))
    {
      result = $""" di."{sDummyItem.ColumnForId}" """;
    }
    else if (field.EqualsToSortField(DummyItemSettings.SortFieldForName))
    {
      result = $""" di."{sDummyItem.ColumnForName}" """;
    }
    else
    {
      throw new NotImplementedException();
    }

    return result;
  }
}
