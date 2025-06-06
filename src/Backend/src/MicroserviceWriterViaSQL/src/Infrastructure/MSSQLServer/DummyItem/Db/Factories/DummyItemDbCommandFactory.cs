﻿namespace Makc.Dummy.MicroserviceWriterViaSQL.Infrastructure.MSSQLServer.DummyItem.Db.Factories;

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

    string fieldsSQL = CretateFieldsSQL();

    result.TextBuilder.Append($$"""
select
  {{fieldsSQL}}
from
  "{{sDummyItem.Schema}}"."{{sDummyItem.Table}}"
where
  "{{sDummyItem.ColumnForId}}" = @Id
""");

    result.AddParameter("@Id", query.Id);

    return result;
  }

  /// <inheritdoc/>
  public DbSQLCommand CreateDbCommandForFilter(DummyItemQueryFilterSection? filter)
  {
    DbSQLCommand result = new();

    if (!string.IsNullOrEmpty(filter?.FullTextSearchQuery))
    {
      var sDummyItem = _appDbSettings.Entities.DummyItem;

      result.TextBuilder.AppendLine($$"""
where
  di."{{sDummyItem.ColumnForId}}" like @FullTextSearchQuery
  or
  di."{{sDummyItem.ColumnForName}}" like @FullTextSearchQuery
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
    string maxCountQuery = _appDbSQLCommandHelper.CreateMaxCountSQL(maxCount);

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
  public DbSQLCommand CreateDbCommandForTotalCount(DbSQLCommand dbCommandForFilter)
  {
    DbSQLCommand result = new();

    dbCommandForFilter.CopyParametersTo(result);

    var sDummyItem = _appDbSettings.Entities.DummyItem;

    result.TextBuilder.AppendLine($$""" 
select
  count_big(*)
from
  "{{sDummyItem.Schema}}"."{{sDummyItem.Table}}" di
""");

    result.TextBuilder.AppendLine(dbCommandForFilter.ToString());

    return result;
  }

  private DbSQLCommand CreateDbCommandForItems(
    DbSQLCommand dbCommandForFilter,
    QuerySortSection? sort,
    string maxCountQuery = "")
  {
    DbSQLCommand result = new();

    dbCommandForFilter.CopyParametersTo(result);

    var sDummyItem = _appDbSettings.Entities.DummyItem;

    string fieldsSQL = CretateFieldsSQL("di.");

    result.TextBuilder.AppendLine($$"""
select{{maxCountQuery}}
  {{fieldsSQL}}
from
  "{{sDummyItem.Schema}}"."{{sDummyItem.Table}}" di
""");

    result.TextBuilder.AppendLine(dbCommandForFilter.ToString());

    _appDbSQLCommandHelper.AddSorting(
      result,
      sort,
      DummyItemSettings.DefaultQuerySortSection,
      CreateOrderByFieldSQL);

    return result;
  }

  private string CretateFieldsSQL(string prefix = "")
  {
    var sDummyItem = _appDbSettings.Entities.DummyItem;

    return $$"""
  {{prefix}}"{{sDummyItem.ColumnForId}}" "Id",
  {{prefix}}"{{sDummyItem.ColumnForConcurrencyToken}}" "ConcurrencyToken",
  {{prefix}}"{{sDummyItem.ColumnForName}}" "Name"
""";
  }

  private string CreateOrderByFieldSQL(string field)
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
