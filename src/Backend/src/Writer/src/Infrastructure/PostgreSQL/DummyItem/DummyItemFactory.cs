namespace Makc.Dummy.Writer.Infrastructure.PostgreSQL.DummyItem;

/// <summary>
/// Фабрика фиктивного предмета.
/// </summary>
/// <param name="_appDbSettings">Настройки базы данных приложения.</param>
public class DummyItemFactory(AppDbSettings _appDbSettings) : IDummyItemFactory
{
  /// <inheritdoc/>
  public DbSQLCommand CreateDbCommand(DummyItemSingleQuery query)
  {
    DbSQLCommand result = new();

    var sDummyItem = _appDbSettings.Entities.DummyItem;

    result.TextBuilder.Append($$"""
select
  "{{sDummyItem.ColumnForId}}" "Id",
  "{{sDummyItem.ColumnForName}}" "Name"
from
  "{{sDummyItem.Schema}}"."{{sDummyItem.Table}}"
where
  "{{sDummyItem.ColumnForId}}" = @Id
""");

    result.AddParameter("@Id", query.Id);

    return result;
  }

  /// <inheritdoc/>
  public DbSQLCommand CreateDbCommandForFilter(DummyItemCountQuery query)
  {
    DbSQLCommand result = new();

    var filter = query.Filter;

    if (!string.IsNullOrEmpty(filter?.FullTextSearchQuery))
    {
      var sDummyItem = _appDbSettings.Entities.DummyItem;

      result.TextBuilder.AppendLine($$"""
where
  di."{{sDummyItem.ColumnForId}}"::text ilike @FullTextSearchQuery
  or
  di."{{sDummyItem.ColumnForName}}" ilike @FullTextSearchQuery
""");

      result.AddParameter("@FullTextSearchQuery", $"%{filter.FullTextSearchQuery}%");
    }

    return result;
  }

  /// <inheritdoc/>
  public DbSQLCommand CreateDbCommandForItems(DbSQLCommand dbCommandForFilter, QueryPageSection? page)
  {
    DbSQLCommand result = new();

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

    var sDummyItem = _appDbSettings.Entities.DummyItem;

    result.TextBuilder.AppendLine($$""" 
select
  count(*)
from
  "{{sDummyItem.Schema}}"."{{sDummyItem.Table}}"
""");

    result.TextBuilder.AppendLine(dbCommandForFilter.ToString());

    return result;
  }
}
