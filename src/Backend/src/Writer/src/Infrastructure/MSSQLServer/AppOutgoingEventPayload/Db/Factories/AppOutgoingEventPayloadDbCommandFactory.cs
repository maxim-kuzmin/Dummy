namespace Makc.Dummy.Writer.Infrastructure.MSSQLServer.AppOutgoingEventPayload.Db.Factories;

/// <summary>
/// Фабрика команд базы данных полезной нагрузки исходящего события приложения.
/// </summary>
/// <param name="_appDbSettings">Настройки базы данных приложения.</param>
/// <param name="_appDbSQLCommandHelper">Помощник для построения команд базы данных SQL.</param>
public class AppOutgoingEventPayloadDbCommandFactory(
  AppDbSettings _appDbSettings,
  IAppDbSQLCommandHelper _appDbSQLCommandHelper) : IAppOutgoingEventPayloadDbSQLCommandFactory
{
  /// <inheritdoc/>
  public DbSQLCommand CreateDbCommand(AppOutgoingEventPayloadSingleQuery query)
  {
    DbSQLCommand result = new();

    var sAppOutgoingEventPayload = _appDbSettings.Entities.AppOutgoingEventPayload;

    result.TextBuilder.Append($$"""
select
  "{{sAppOutgoingEventPayload.ColumnForId}}" "Id",
  "{{sAppOutgoingEventPayload.ColumnForAppOutgoingEventId}}" "AppOutgoingEventId",
  "{{sAppOutgoingEventPayload.ColumnForData}}" "Data"
from
  "{{sAppOutgoingEventPayload.Schema}}"."{{sAppOutgoingEventPayload.Table}}"
where
  "{{sAppOutgoingEventPayload.ColumnForId}}" = @Id
""");

    result.AddParameter("@Id", query.Id);

    return result;
  }

  /// <inheritdoc/>
  public DbSQLCommand CreateDbCommandForFilter(AppOutgoingEventPayloadPageQuery query)
  {
    DbSQLCommand result = new();

    var filter = query.Filter;

    if (!string.IsNullOrEmpty(filter?.FullTextSearchQuery))
    {
      var sAppOutgoingEventPayload = _appDbSettings.Entities.AppOutgoingEventPayload;

      result.TextBuilder.AppendLine($$"""
where
  aep."{{sAppOutgoingEventPayload.ColumnForId}}" like @FullTextSearchQuery
  or
  aep."{{sAppOutgoingEventPayload.ColumnForData}}" like @FullTextSearchQuery
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

    var sAppOutgoingEventPayload = _appDbSettings.Entities.AppOutgoingEventPayload;

    result.TextBuilder.AppendLine($$"""
select
  aep."{{sAppOutgoingEventPayload.ColumnForId}}" "Id",
  aep."{{sAppOutgoingEventPayload.ColumnForAppOutgoingEventId}}" "AppOutgoingEventId",
  aep."{{sAppOutgoingEventPayload.ColumnForData}}" "Data"
from
  "{{sAppOutgoingEventPayload.Schema}}"."{{sAppOutgoingEventPayload.Table}}" aep
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

    var sAppOutgoingEventPayload = _appDbSettings.Entities.AppOutgoingEventPayload;

    result.TextBuilder.AppendLine($$""" 
select
  count_big(*)
from
  "{{sAppOutgoingEventPayload.Schema}}"."{{sAppOutgoingEventPayload.Table}}" aep
""");

    result.TextBuilder.AppendLine(dbCommandForFilter.ToString());

    return result;
  }

  private string CreateOrderByField(string field)
  {
    string result;

    var sAppOutgoingEventPayload = _appDbSettings.Entities.AppOutgoingEventPayload;

    if (field.EqualsToSortField(AppOutgoingEventPayloadSettings.SortFieldForAppOutgoingEventId))
    {
      result = $""" aep."{sAppOutgoingEventPayload.ColumnForAppOutgoingEventId}" """;
    }
    else if (field.EqualsToSortField(AppOutgoingEventPayloadSettings.SortFieldForData))
    {
      result = $""" aep."{sAppOutgoingEventPayload.ColumnForData}" """;
    }
    else if (field.EqualsToSortField(AppOutgoingEventPayloadSettings.SortFieldForId))
    {
      result = $""" aep."{sAppOutgoingEventPayload.ColumnForId}" """;
    }
    else
    {
      throw new NotImplementedException();
    }

    return result;
  }
}
