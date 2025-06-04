namespace Makc.Dummy.MicroserviceWriterViaSQL.Infrastructure.PostgreSQL.AppOutgoingEventPayload.Db.Factories;

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

    string fieldsSQL = CretateFieldsSQL();

    result.TextBuilder.Append($$"""
select
  {{fieldsSQL}}
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

    if (filter == null)
    {
      return result;
    }

    bool shouldBeFilteredByFullTextSearchQuery = !string.IsNullOrEmpty(filter.FullTextSearchQuery);
    bool shouldBeFilteredByAppOutgoingEventId = filter.AppOutgoingEventId > 0;

    bool shouldBeFiltered = shouldBeFilteredByFullTextSearchQuery || shouldBeFilteredByAppOutgoingEventId;

    if (!shouldBeFiltered)
    {
      return result;
    }

    result.TextBuilder.AppendLine($$"""
where
""");

    var sAppOutgoingEventPayload = _appDbSettings.Entities.AppOutgoingEventPayload;

    if (shouldBeFilteredByFullTextSearchQuery)
    {
      result.TextBuilder.AppendLine($$"""
  (
    aep."{{sAppOutgoingEventPayload.ColumnForId}}" like @FullTextSearchQuery
    or
    aep."{{sAppOutgoingEventPayload.ColumnForData}}" like @FullTextSearchQuery
  )
""");

      result.AddParameter("@FullTextSearchQuery", $"%{filter.FullTextSearchQuery}%");
    }

    if (shouldBeFilteredByAppOutgoingEventId)
    {
      result.TextBuilder.AppendLine($$"""
  and
  aep."{{sAppOutgoingEventPayload.ColumnForId}}" = @AppOutgoingEventId
""");

      result.AddParameter("@AppOutgoingEventId", filter.AppOutgoingEventId);
    }

    return result;
  }

  /// <inheritdoc/>
  public DbSQLCommand CreateDbCommandForItems(
    DbSQLCommand dbCommandForFilter,
    QuerySortSection? sort,
    int maxCount)
  {
    string maxCountSQL = _appDbSQLCommandHelper.CreateMaxCountSQL(maxCount);

    return CreateDbCommandForItems(dbCommandForFilter, sort, maxCountSQL);
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

  private DbSQLCommand CreateDbCommandForItems(
    DbSQLCommand dbCommandForFilter,
    QuerySortSection? sort,
    string maxCountSQL = "")
  {
    DbSQLCommand result = new();

    dbCommandForFilter.CopyParametersTo(result);

    var sAppOutgoingEventPayload = _appDbSettings.Entities.AppOutgoingEventPayload;

    string fieldsSQL = CretateFieldsSQL("aep.");

    result.TextBuilder.AppendLine($$"""
select
  {{fieldsSQL}}
from
  "{{sAppOutgoingEventPayload.Schema}}"."{{sAppOutgoingEventPayload.Table}}" aep
""");

    result.TextBuilder.AppendLine(dbCommandForFilter.ToString());

    _appDbSQLCommandHelper.AddSorting(
      result,
      sort,
      AppOutgoingEventPayloadSettings.DefaultQuerySortSection,
      CreateOrderByFieldSQL);

    if (!string.IsNullOrWhiteSpace(maxCountSQL))
    {
      result.TextBuilder.Append(maxCountSQL);
    }

    return result;
  }

  private string CretateFieldsSQL(string prefix = "")
  {
    var sAppOutgoingEventPayload = _appDbSettings.Entities.AppOutgoingEventPayload;

    return $$"""
  {{prefix}}"{{sAppOutgoingEventPayload.ColumnForId}}" "Id",
  {{prefix}}"{{sAppOutgoingEventPayload.ColumnForConcurrencyToken}}" "ConcurrencyToken",
  {{prefix}}"{{sAppOutgoingEventPayload.ColumnForAppOutgoingEventId}}" "AppOutgoingEventId",
  {{prefix}}"{{sAppOutgoingEventPayload.ColumnForData}}" "Data",
  {{prefix}}"{{sAppOutgoingEventPayload.ColumnForEntityConcurrencyTokenToDelete}}" "EntityConcurrencyTokenToDelete",
  {{prefix}}"{{sAppOutgoingEventPayload.ColumnForEntityConcurrencyTokenToInsert}}" "EntityConcurrencyTokenToInsert",
  {{prefix}}"{{sAppOutgoingEventPayload.ColumnForEntityId}}" "EntityId",
  {{prefix}}"{{sAppOutgoingEventPayload.ColumnForEntityName}}" "EntityName",
  {{prefix}}"{{sAppOutgoingEventPayload.ColumnForPosition}}" "Position"
""";
  }

  private string CreateOrderByFieldSQL(string field)
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
