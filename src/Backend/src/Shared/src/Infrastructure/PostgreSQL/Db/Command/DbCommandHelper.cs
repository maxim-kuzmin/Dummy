namespace Makc.Dummy.Shared.Infrastructure.PostgreSQL.Db.Command;

/// <summary>
/// Помощник для построения команд базы данных.
/// </summary>
public class DbCommandHelper : DbSQLCommandHelper
{
  /// <inheritdoc/>
  public sealed override void AddPagination(DbSQLCommand dbCommand, QueryPageSection? page)
  {
    if (page == null)
    {
      return;
    }

    if (page.Size > 0)
    {
      dbCommand.TextBuilder.AppendLine("limit @PageSize");

      dbCommand.AddParameter("@PageSize", page.Size);
    }

    if (page.Number > 0)
    {
      dbCommand.TextBuilder.AppendLine("offset @PageNumber");

      dbCommand.AddParameter("@PageNumber", page.ToSkip());
    }
  }

  /// <inheritdoc/>
  public sealed override string GetMaxCountQuery(int maxCount)
  {
    return maxCount > 0 ? $" limit {maxCount}" : string.Empty;
  }
}
