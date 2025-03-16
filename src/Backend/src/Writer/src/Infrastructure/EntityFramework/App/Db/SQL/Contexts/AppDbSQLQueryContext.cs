namespace Makc.Dummy.Writer.Infrastructure.EntityFramework.App.Db.SQL.Contexts;

/// <summary>
/// Контекст запроса базы данных SQL приложения.
/// </summary>
/// <param name="dbContext">Контекст базы данных.</param>
public class AppDbSQLQueryContext(AppDbContext dbContext) :
  DbSQLQueryContext<AppDbContext>(dbContext),
  IAppDbSQLQueryContext
{
}
