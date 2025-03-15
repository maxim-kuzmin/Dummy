namespace Makc.Dummy.Writer.Infrastructure.MSSQLServer.AppEvent.Db.Command;

/// <summary>
/// Фабрика команд базы данных полезной нагрузки события приложения.
/// </summary>
/// <param name="_appDbSettings">Настройки базы данных приложения.</param>
public class AppEventDbCommandFactory(AppDbSettings _appDbSettings) : IAppEventDbSQLCommandFactory
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
  ae."{{sAppEvent.ColumnForId}}" like @FullTextSearchQuery
  or
  ae."{{sAppEvent.ColumnForName}}" like @FullTextSearchQuery
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

    var sAppEvent = _appDbSettings.Entities.AppEvent;

    if (sort == null)
    {
      sort = AppEventSettings.DefaultQuerySortSection;
    }

    var orderByDirection = sort.IsDesc ? "desc" : "asc";

    string orderByField;

    if (sort.Field.EqualsToSortField(AppEventSettings.SortFieldForId))
    {
      orderByField = $""" ae."{sAppEvent.ColumnForId}" """;
    }
    else if (sort.Field.EqualsToSortField(AppEventSettings.SortFieldForName))
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

      if (page.Number > 0)
      {
        result.TextBuilder.AppendLine($$"""        
offset @PageNumber rows
""");

        if (page.Size > 0)
        {
          result.TextBuilder.AppendLine($$"""        
fetch next @PageSize rows only        
""");

          result.AddParameter("@PageSize", page.Size);
        }

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
  count_big(*)
from
  "{{sAppEvent.Schema}}"."{{sAppEvent.Table}}"
""");

    result.TextBuilder.AppendLine(dbCommandForFilter.ToString());

    return result;
  }
}
