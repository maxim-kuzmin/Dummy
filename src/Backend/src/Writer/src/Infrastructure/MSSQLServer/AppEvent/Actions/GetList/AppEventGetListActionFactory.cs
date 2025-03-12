﻿namespace Makc.Dummy.Writer.Infrastructure.MSSQLServer.AppEvent.Actions.GetList;

/// <summary>
/// Фабрика действия по получению списка фиктивных предметов.
/// </summary>
/// <param name="_appDbSettings">Настройки базы данных приложения.</param>
public class AppEventGetListActionFactory(AppDbSettings _appDbSettings) : IAppEventGetListActionFactory
{
  /// <inheritdoc/>
  public DbSQLCommand CreateDbCommandForFilter(AppEventGetListActionQuery query)
  {
    DbSQLCommand result = new();

    var sAppEvent = _appDbSettings.Entities.AppEvent;

    if (!string.IsNullOrEmpty(query.Filter?.FullTextSearchQuery))
    {
      result.TextBuilder.AppendLine($$"""
where
  ae."{{sAppEvent.ColumnForId}}" like @FullTextSearchQuery
  or
  ae."{{sAppEvent.ColumnForName}}" like @FullTextSearchQuery
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

    var sAppEvent = _appDbSettings.Entities.AppEvent;

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
  ae."{{sAppEvent.ColumnForId}}" desc    
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
  count(*)
from
  "{{sAppEvent.Schema}}"."{{sAppEvent.Table}}" ae
""");

    result.TextBuilder.AppendLine(dbCommandForFilter.ToString());

    return result;
  }
}
