namespace Makc.Dummy.Writer.Infrastructure.EntityFramework.App.Db.Contexts;

/// <summary>
/// Контекст выполнения базы данных приложения.
/// </summary>
/// <param name="dbContext">Контекст базы данных.</param>
public class AppDbExecutionContext(AppDbContext dbContext) : DbExecutionContext(dbContext), IAppDbExecutionContext
{
}
