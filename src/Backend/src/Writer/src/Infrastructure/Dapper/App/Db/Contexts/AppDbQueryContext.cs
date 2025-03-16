namespace Makc.Dummy.Writer.Infrastructure.Dapper.App.Db.Contexts;

/// <summary>
/// Контекст запросов базы данных приложения.
/// </summary>
/// <param name="dbContext">Контекст базы данных.</param>
public class AppDbQueryContext(IAppDbContext dbContext) :
  DbQueryContext<IAppDbContext>(dbContext),
  IAppDbSQLQueryContext
{
}
