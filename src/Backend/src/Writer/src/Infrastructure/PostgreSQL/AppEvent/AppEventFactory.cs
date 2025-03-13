namespace Makc.Dummy.Writer.Infrastructure.PostgreSQL.AppEvent;

/// <summary>
/// Фабрика события приложения.
/// </summary>
/// <param name="_appDbSettings">Настройки базы данных приложения.</param>
public class AppEventFactory(AppDbSettings _appDbSettings) : IAppEventUseCasesFactory
{
  /// <inheritdoc/>
  public DbSQLCommand CreateDbCommand(AppEventSingleQuery query)
  {
    DbSQLCommand result = new();

    var sAppEvent = _appDbSettings.Entities.AppEvent;

    result.TextBuilder.Append($$"""
select
  "{{sAppEvent.ColumnForId}}" "Id",
  "{{sAppEvent.ColumnForCreatedAt}}" "CreatedAt",
  "{{sAppEvent.ColumnForIsPublished}}" "IsPublished",
  "{{sAppEvent.ColumnForName}}" "Name"
from
  "{{sAppEvent.Schema}}"."{{sAppEvent.Table}}"
where
  "{{sAppEvent.ColumnForId}}" = @Id
""");

    result.AddParameter("@Id", query.Id);

    return result;
  }

  /// <inheritdoc/>
  public DbSQLCommand CreateDbCommandForFilter(AppEventPageQuery query)
  {
    DbSQLCommand result = new();

    var filter = query.Filter;

    if (!string.IsNullOrEmpty(filter?.FullTextSearchQuery))
    {
      var sAppEvent = _appDbSettings.Entities.AppEvent;

      result.TextBuilder.AppendLine($$"""
where
  ae."{{sAppEvent.ColumnForId}}"::text ilike @FullTextSearchQuery
  or
  ae."{{sAppEvent.ColumnForName}}" ilike @FullTextSearchQuery
""");

      result.AddParameter("@FullTextSearchQuery", $"%{filter.FullTextSearchQuery}%");
    }

    return result;
  }

  /// <inheritdoc/>
  public DbSQLCommand CreateDbCommandForItems(
    DbSQLCommand dbCommandForFilter,
    QueryPageSection? page,
    QueryOrderSection? order)
  {
    DbSQLCommand result = new();

    dbCommandForFilter.CopyParametersTo(result);

    var sAppEvent = _appDbSettings.Entities.AppEvent;

    if (order == null)
    {
      order = AppEventSettings.DefaultQueryOrderSection;
    }

    string orderByDirection = order.IsDesc ? "desc" : "asc";

    string orderByField;

    if (order.Field.EqualsToOrderField(AppEventSettings.OrderFieldForId))
    {
      orderByField = $""" ae."{sAppEvent.ColumnForId}" """;
    }
    else if (order.Field.EqualsToOrderField(AppEventSettings.OrderFieldForName))
    {
      orderByField = $""" ae."{sAppEvent.ColumnForName}" """;
    }
    else
    {
      throw new NotImplementedException();
    }

    result.TextBuilder.AppendLine($$"""
select
  ae."{{sAppEvent.ColumnForId}}" "Id",
  ae."{{sAppEvent.ColumnForCreatedAt}}" "CreatedAt",
  ae."{{sAppEvent.ColumnForIsPublished}}" "IsPublished",
  ae."{{sAppEvent.ColumnForName}}" "Name"
from
  "{{sAppEvent.Schema}}"."{{sAppEvent.Table}}" ae
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

    var sAppEvent = _appDbSettings.Entities.AppEvent;

    result.TextBuilder.AppendLine($$"""
select
  count(*)
from
  "{{sAppEvent.Schema}}"."{{sAppEvent.Table}}"
""");

    result.TextBuilder.AppendLine(dbCommandForFilter.ToString());

    return result;
  }
}
