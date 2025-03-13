namespace Makc.Dummy.Writer.Infrastructure.MSSQLServer.DummyItem;

/// <summary>
/// Фабрика фиктивного предмета.
/// </summary>
/// <param name="_appDbSettings">Настройки базы данных приложения.</param>
public class DummyItemFactory(AppDbSettings _appDbSettings) : IDummyItemUseCasesFactory
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
  public DbSQLCommand CreateDbCommandForFilter(DummyItemPageQuery query)
  {
    DbSQLCommand result = new();

    var filter = query.Filter;

    if (!string.IsNullOrEmpty(filter?.FullTextSearchQuery))
    {
      var sDummyItem = _appDbSettings.Entities.DummyItem;

      result.TextBuilder.AppendLine($$"""
where
  di."{{sDummyItem.ColumnForId}}" like @FullTextSearchQuery
  or
  di."{{sDummyItem.ColumnForName}}" like @FullTextSearchQuery
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

    var sDummyItem = _appDbSettings.Entities.DummyItem;

    if (order == null)
    {
      order = DummyItemSettings.DefaultQueryOrderSection;
    }

    string orderByDirection = order.IsDesc ? "desc" : "asc";

    string orderByField;

    if (order.Field.EqualsToOrderField(DummyItemSettings.OrderFieldForId))
    {
      orderByField = $""" di."{sDummyItem.ColumnForId}" """;
    }
    else if (order.Field.EqualsToOrderField(DummyItemSettings.OrderFieldForName))
    {
      orderByField = $""" di."{sDummyItem.ColumnForName}" """;
    }
    else
    {
      throw new NotImplementedException();
    }

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

    var sDummyItem = _appDbSettings.Entities.DummyItem;

    result.TextBuilder.AppendLine($$""" 
select
  count_big(*)
from
  "{{sDummyItem.Schema}}"."{{sDummyItem.Table}}"
""");

    result.TextBuilder.AppendLine(dbCommandForFilter.ToString());

    return result;
  }
}
