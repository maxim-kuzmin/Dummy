namespace Makc.Dummy.Writer.Infrastructure.MSSQLServer.DummyItem.Actions.GetList;

/// <summary>
/// Фабрика действия по получению списка фиктивных предметов.
/// </summary>
/// <param name="_appDbSettings">Настройки базы данных приложения.</param>
public class DummyItemGetListActionFactory(AppDbSettings _appDbSettings) : IDummyItemGetListActionFactory
{
  /// <inheritdoc/>
  public DbCommand CreateDbCommandForFilter(DummyItemGetListActionQuery query)
  {
    DbCommand result = new();

    var sDummyItem = _appDbSettings.Entities.DummyItem;

    if (!string.IsNullOrEmpty(query.Filter?.FullTextSearchQuery))
    {
      result.TextBuilder.AppendLine($$"""
where
  di."{{sDummyItem.ColumnForId}}" like @FullTextSearchQuery
  or
  di."{{sDummyItem.ColumnForName}}" like @FullTextSearchQuery
""");

      result.AddParameter("@FullTextSearchQuery", $"%{query.Filter.FullTextSearchQuery}%");
    }

    return result;
  }

  /// <inheritdoc/>
  public DbCommand CreateDbCommandForItems(DbCommand dbCommandForFilter, QueryPage? page)
  {
    DbCommand result = new();

    dbCommandForFilter.CopyParametersTo(result);

    var sDummyItem = _appDbSettings.Entities.DummyItem;

    result.TextBuilder.AppendLine($$"""
select
  di."{{sDummyItem.ColumnForId}}" "Id",
  di."{{sDummyItem.ColumnForName}}" "Name"
from
  "{{sDummyItem.Schema}}"."{{sDummyItem.Table}}" di
""");

    result.TextBuilder.AppendLine(dbCommandForFilter.ToString());

    result.TextBuilder.AppendLine($$"""
order by
  di."{{sDummyItem.ColumnForId}}" desc
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
  public DbCommand CreateDbCommandForTotalCount(DbCommand dbCommandForFilter)
  {
    DbCommand result = new();

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
}
