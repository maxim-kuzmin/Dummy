namespace Makc.Dummy.MicroserviceWriter.Infrastructure.EntityFramework.App.Db.SQL.Contexts;

/// <summary>
/// Контекст выполнения базы данных SQL приложения.
/// </summary>
/// <param name="dbContext">Контекст базы данных.</param>
public class AppDbSQLExecutionContext(AppDbContext dbContext) : DbSQLExecutionContext(dbContext), IAppDbSQLExecutionContext
{
}
