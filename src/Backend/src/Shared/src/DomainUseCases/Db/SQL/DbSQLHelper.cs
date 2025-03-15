namespace Makc.Dummy.Shared.DomainUseCases.Db.SQL;

/// <summary>
/// Помощник базы данных SQL.
/// </summary>
public abstract class DbSQLHelper : IDbSQLHelper
{
  /// <inheritdoc/>
  public abstract void AddPagination(DbSQLCommand dbCommand, QueryPageSection? page);

  /// <inheritdoc/>
  public void AddSorting(
    DbSQLCommand dbCommand,
    QuerySortSection? sort,
    QuerySortSection defaultSort,
    Func<string, string> funcToCreateOrderByField)
  {
    if (sort == null)
    {
      sort = defaultSort;
    }

    var orderByDirection = sort.IsDesc ? "desc" : "asc";

    var orderByField = funcToCreateOrderByField.Invoke(sort.Field);

    dbCommand.TextBuilder.AppendLine($" order by {orderByField} {orderByDirection}");
  }
}
