namespace Makc.Dummy.MicroserviceWriter.Infrastructure.PostgreSQL.AppOutgoingEventPayload.Db.Factories;

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
  "{{sAppOutgoingEventPayload.ColumnForConcurrencyToken}}" "ConcurrencyToken",
  "{{sAppOutgoingEventPayload.ColumnForAppOutgoingEventId}}" "AppOutgoingEventId",
  "{{sAppOutgoingEventPayload.ColumnForData}}" "Data",
  "{{sAppOutgoingEventPayload.ColumnForEntityConcurrencyTokenToDelete}}" "EntityConcurrencyTokenToDelete",
  "{{sAppOutgoingEventPayload.ColumnForEntityConcurrencyTokenToInsert}}" "EntityConcurrencyTokenToInsert",
  "{{sAppOutgoingEventPayload.ColumnForEntityId}}" "EntityId",
  "{{sAppOutgoingEventPayload.ColumnForEntityName}}" "EntityName",
  "{{sAppOutgoingEventPayload.ColumnForPosition}}" "Position"
from
  "{{sAppOutgoingEventPayload.Schema}}"."{{sAppOutgoingEventPayload.Table}}"
where
  "{{sAppOutgoingEventPayload.ColumnForId}}" = @Id
""");

    result.AddParameter("@Id", query.Id);

    return result;
  }

  /// <inheritdoc/>
  public DbSQLCommand CreateDbCommandForFilter(AppOutgoingEventPayloadQueryFilterSection? filter)
  {
    DbSQLCommand result = new();

    if (!string.IsNullOrEmpty(filter?.FullTextSearchQuery))
    {
      var sAppOutgoingEventPayload = _appDbSettings.Entities.AppOutgoingEventPayload;

      result.TextBuilder.AppendLine($$"""
where
  aep."{{sAppOutgoingEventPayload.ColumnForId}}"::text ilike @FullTextSearchQuery
  or
  aep."{{sAppOutgoingEventPayload.ColumnForData}}" ilike @FullTextSearchQuery
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

    var sAppOutgoingEventPayload = _appDbSettings.Entities.AppOutgoingEventPayload;

    result.TextBuilder.AppendLine($$"""
select
  aep."{{sAppOutgoingEventPayload.ColumnForId}}" "Id",
  aep."{{sAppOutgoingEventPayload.ColumnForConcurrencyToken}}" "ConcurrencyToken",
  aep."{{sAppOutgoingEventPayload.ColumnForAppOutgoingEventId}}" "AppOutgoingEventId",
  aep."{{sAppOutgoingEventPayload.ColumnForData}}" "Data",
  aep."{{sAppOutgoingEventPayload.ColumnForEntityConcurrencyTokenToDelete}}" "EntityConcurrencyTokenToDelete",
  aep."{{sAppOutgoingEventPayload.ColumnForEntityConcurrencyTokenToInsert}}" "EntityConcurrencyTokenToInsert",
  aep."{{sAppOutgoingEventPayload.ColumnForEntityId}}" "EntityId",
  aep."{{sAppOutgoingEventPayload.ColumnForEntityName}}" "EntityName",
  aep."{{sAppOutgoingEventPayload.ColumnForPosition}}" "Position"
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
  count(*)
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
    else if (field.EqualsToSortField(AppOutgoingEventPayloadSettings.SortFieldForEntityConcurrencyTokenToDelete))
    {
      result = $""" aep."{sAppOutgoingEventPayload.ColumnForEntityConcurrencyTokenToDelete}" """;
    }
    else if (field.EqualsToSortField(AppOutgoingEventPayloadSettings.SortFieldForEntityConcurrencyTokenToInsert))
    {
      result = $""" aep."{sAppOutgoingEventPayload.ColumnForEntityConcurrencyTokenToInsert}" """;
    }
    else if (field.EqualsToSortField(AppOutgoingEventPayloadSettings.SortFieldForEntityId))
    {
      result = $""" aep."{sAppOutgoingEventPayload.ColumnForEntityId}" """;
    }
    else if (field.EqualsToSortField(AppOutgoingEventPayloadSettings.SortFieldForEntityName))
    {
      result = $""" aep."{sAppOutgoingEventPayload.ColumnForEntityName}" """;
    }
    else if (field.EqualsToSortField(AppOutgoingEventPayloadSettings.SortFieldForId))
    {
      result = $""" aep."{sAppOutgoingEventPayload.ColumnForId}" """;
    }
    else if (field.EqualsToSortField(AppOutgoingEventPayloadSettings.SortFieldForPosition))
    {
      result = $""" aep."{sAppOutgoingEventPayload.ColumnForPosition}" """;
    }
    else
    {
      throw new NotImplementedException();
    }

    return result;
  }
}
