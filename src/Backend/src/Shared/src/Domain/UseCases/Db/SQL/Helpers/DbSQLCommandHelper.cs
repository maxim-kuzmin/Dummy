namespace Makc.Dummy.Shared.Domain.UseCases.Db.SQL.Helpers;

/// <summary>
/// Помощник для построения команд базы данных SQL.
/// </summary>
public abstract class DbSQLCommandHelper : IDbSQLCommandHelper
{
  /// <inheritdoc/>
  public abstract void AddPagination(DbSQLCommand dbCommand, QueryPageSection? page);

  /// <inheritdoc/>
  public void AddSorting(
    DbSQLCommand dbCommand,
    QuerySortSection? sort,
    QuerySortSection defaultSort,
    Func<string, string> funcToCreateOrderByFieldSQL)
  {
    if (sort == null)
    {
      sort = defaultSort;
    }

    var orderByDirection = sort.IsDesc ? "desc" : "asc";

    var orderByFieldSQL = funcToCreateOrderByFieldSQL.Invoke(sort.Field);

    dbCommand.TextBuilder.AppendLine($"order by {orderByFieldSQL} {orderByDirection}");
  }

  /// <inheritdoc/>
  public abstract string CreateMaxCountSQL(int maxCount);
}
