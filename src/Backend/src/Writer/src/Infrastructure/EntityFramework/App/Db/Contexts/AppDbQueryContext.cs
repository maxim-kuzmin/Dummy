namespace Makc.Dummy.Writer.Infrastructure.EntityFramework.App.Db.Contexts;

/// <summary>
/// Контекст запроса базы данных приложения.
/// </summary>
/// <param name="dbContext">Контекст базы данных.</param>
public class AppDbQueryContext(AppDbContext dbContext) :
  DbSQLQueryContext<AppDbContext>(dbContext),
  IAppDbQueryContext
{
}
