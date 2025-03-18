namespace Makc.Dummy.Reader.Infrastructure.MongoDB.App.Db.Contexts;

/// <summary>
/// Контекст выполнения базы данных приложения
/// </summary>
public class AppDbExecutionContext(
  IClientSessionHandle clientSessionHandle) : DbExecutionContext(clientSessionHandle), IAppDbNoSQLExecutionContext
{
}
