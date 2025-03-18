namespace Makc.Dummy.Shared.Infrastructure.MSSQLServer.Db.Helpers;

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

    if (page.Number > 0)
    {
      dbCommand.TextBuilder.AppendLine("offset @PageNumber rows");

      dbCommand.AddParameter("@PageNumber", (page.Number - 1) * page.Size);
    }

    if (page.Size > 0)
    {
      dbCommand.TextBuilder.AppendLine("fetch next @PageSize rows only");

      dbCommand.AddParameter("@PageSize", page.Size);
    }
  }
}
