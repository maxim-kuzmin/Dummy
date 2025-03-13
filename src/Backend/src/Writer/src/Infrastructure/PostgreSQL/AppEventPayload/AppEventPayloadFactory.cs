namespace Makc.Dummy.Writer.Infrastructure.PostgreSQL.AppEventPayload;

/// <summary>
/// Фабрика полезной нагрузки события приложения.
/// </summary>
/// <param name="_appDbSettings">Настройки базы данных приложения.</param>
public class AppEventPayloadFactory(AppDbSettings _appDbSettings) : IAppEventPayloadUseCasesFactory
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
  aep."{{sAppEventPayload.ColumnForId}}"::text ilike @FullTextSearchQuery
  or
  aep."{{sAppEventPayload.ColumnForData}}" ilike @FullTextSearchQuery
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

    if (sort == null)
    {
      sort = AppEventPayloadSettings.DefaultQuerySortSection;
    }

    string orderByDirection = sort.IsDesc ? "desc" : "asc";

    string orderByField;

    if (sort.Field.EqualsToSortField(AppEventPayloadSettings.SortFieldForAppEventId))
    {
      orderByField = $""" aep."{sAppEventPayload.ColumnForAppEventId}" """;
    }
    else if (sort.Field.EqualsToSortField(AppEventPayloadSettings.SortFieldForData))
    {
      orderByField = $""" aep."{sAppEventPayload.ColumnForData}" """;
    }
    else if (sort.Field.EqualsToSortField(AppEventPayloadSettings.SortFieldForId))
    {
      orderByField = $""" aep."{sAppEventPayload.ColumnForId}" """;
    }
    else
    {
      throw new NotImplementedException();
    }

    result.TextBuilder.AppendLine($$"""
select
  aep."{{sAppEventPayload.ColumnForId}}" "Id",
  aep."{{sAppEventPayload.ColumnForAppEventId}}" "AppEventId",
  aep."{{sAppEventPayload.ColumnForData}}" "Data"
from
  "{{sAppEventPayload.Schema}}"."{{sAppEventPayload.Table}}" aep
""");

    result.TextBuilder.AppendLine(dbCommandForFilter.ToString());

    result.TextBuilder.AppendLine($$"""
order by
  {{orderByField}} {{orderByDirection}}  
""");

    if (page != null)
    {
      if (page.Size > 0)
      {
        result.TextBuilder.AppendLine($$"""        
limit @PageSize        
""");

        result.AddParameter("@PageSize", page.Size);
      }

      if (page.Number > 0)
      {
        result.TextBuilder.AppendLine($$"""        
offset @PageNumber
""");

        result.AddParameter("@PageNumber", (page.Number - 1) * page.Size);
      }
    }

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
  count(*)
from
  "{{sAppEventPayload.Schema}}"."{{sAppEventPayload.Table}}"
""");

    result.TextBuilder.AppendLine(dbCommandForFilter.ToString());

    return result;
  }
}
