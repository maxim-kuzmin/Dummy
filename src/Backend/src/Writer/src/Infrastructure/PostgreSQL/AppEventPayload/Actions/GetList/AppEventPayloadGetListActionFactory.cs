namespace Makc.Dummy.Writer.Infrastructure.PostgreSQL.AppEventPayload.Actions.GetList;

/// <summary>
/// Фабрика действия по получению списка фиктивных предметов.
/// </summary>
/// <param name="_appDbSettings">Настройки базы данных приложения.</param>
public class AppEventPayloadGetListActionFactory(AppDbSettings _appDbSettings) : IAppEventPayloadGetListActionFactory
{
  /// <inheritdoc/>
  public DbSQLCommand CreateDbCommandForFilter(AppEventPayloadGetListActionQuery query)
  {
    DbSQLCommand result = new();

    var sAppEventPayload = _appDbSettings.Entities.AppEventPayload;

    if (!string.IsNullOrEmpty(query.Filter?.FullTextSearchQuery))
    {
      result.TextBuilder.AppendLine($$"""
where
  aep."{{sAppEventPayload.ColumnForId}}"::text ilike @FullTextSearchQuery
  or
  aep."{{sAppEventPayload.ColumnForData}}" ilike @FullTextSearchQuery
""");

      result.AddParameter("@FullTextSearchQuery", $"%{query.Filter.FullTextSearchQuery}%");
    }

    return result;
  }

  /// <inheritdoc/>
  public DbSQLCommand CreateDbCommandForItems(DbSQLCommand dbCommandForFilter, QueryPageSection? page)
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

    result.TextBuilder.AppendLine($$"""
order by
  aep."{{sAppEventPayload.ColumnForId}}" desc    
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
  "{{sAppEventPayload.Schema}}"."{{sAppEventPayload.Table}}" aep
""");

    result.TextBuilder.AppendLine(dbCommandForFilter.ToString());

    return result;
  }
}
