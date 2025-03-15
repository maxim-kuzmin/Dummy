﻿namespace Makc.Dummy.Shared.Infrastructure.MSSQLServer.Db;

/// <summary>
/// Помощник базы данных.
/// </summary>
public class DbHelper : DbSQLHelper
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
      dbCommand.TextBuilder.AppendLine(" offset @PageNumber rows ");

      dbCommand.AddParameter("@PageNumber", (page.Number - 1) * page.Size);
    }

    if (page.Size > 0)
    {
      dbCommand.TextBuilder.AppendLine(" fetch next @PageSize rows only ");

      dbCommand.AddParameter("@PageSize", page.Size);
    }
  }
}
