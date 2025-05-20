namespace Makc.Dummy.Shared.Domain.UseCases.Db.SQL.Contexts;

/// <summary>
/// Интерфейс контекста выполнения базы данных SQL.
/// </summary>
public interface IDbSQLExecutionContext : IExecutionContext
{
  /// <summary>
  /// С уровнем изоляции.
  /// </summary>
  /// <param name="isolationLevel">Уровень изоляции.</param>
  /// <returns>Исполнитель базы данных.</returns>
  IDbSQLExecutionContext WithIsolationLevel(IsolationLevel isolationLevel);

  /// <summary>
  /// С сохранением изменений.
  /// </summary>
  /// <returns>Исполнитель базы данных.</returns>
  IDbSQLExecutionContext WithSaveChanges();
}
