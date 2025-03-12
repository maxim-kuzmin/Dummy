namespace Makc.Dummy.Shared.DomainUseCases.Execution;

/// <summary>
/// Интерфейс основы контекста выполнения базы данных.
/// </summary>
public interface IExecutionContext
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
}
