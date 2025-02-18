namespace Makc.Dummy.Shared.DomainUseCases.Db.Contexts;

/// <summary>
/// Интерфейс контекста выполнения базы данных.
/// </summary>
public interface IDbExecutionContext
{
  /// <summary>
  /// Выполнить.
  /// </summary>
  /// <param name="funcToExecute">Функция для выполнения.</param>
  /// <param name="cancellationToken">Токен отмены.</param>
  /// <returns>Задача.</returns>
  Task Execute(Func<CancellationToken, Task> funcToExecute, CancellationToken cancellationToken);

  /// <summary>
  /// Выполнить в транзакции.
  /// </summary>
  /// <param name="funcToExecute">Функция для выполнения.</param>
  /// <param name="cancellationToken">Токен отмены.</param>
  /// <returns>Задача.</returns>
  Task ExecuteInTransaction(Func<CancellationToken, Task> funcToExecute, CancellationToken cancellationToken);

  /// <summary>
  /// С уровнем изоляции.
  /// </summary>
  /// <param name="isolationLevel">Уровень изоляции.</param>
  /// <returns>Исполнитель базы данных.</returns>
  IDbExecutionContext WithIsolationLevel(IsolationLevel isolationLevel);

  /// <summary>
  /// С сохранением изменений.
  /// </summary>
  /// <returns>Исполнитель базы данных.</returns>
  IDbExecutionContext WithSaveChanges();
}
