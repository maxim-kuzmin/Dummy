namespace Makc.Dummy.Shared.Infrastructure.MongoDB.Db.Contexts;

/// <summary>
/// Контекст выполнения базы данных.
/// </summary>
public class DbExecutionContext : IDbNoSQLExecutionContext
{
  private readonly IClientSessionHandle _clientSessionHandle;

  private bool _isExecuting;

  /// <summary>
  /// Конструктор.
  /// </summary>
  /// <param name="clientSessionHandle">Описатель сессии клиента.</param>
  public DbExecutionContext(IClientSessionHandle clientSessionHandle)
  {
    _clientSessionHandle = clientSessionHandle;

    Reset();
  }

  /// <inheritdoc/>
  public Task Execute(Func<CancellationToken, Task> funcToExecute, CancellationToken cancellationToken)
  {
    return Execute(funcToExecute, false, cancellationToken);
  }

  /// <inheritdoc/>
  public Task ExecuteInTransaction(Func<CancellationToken, Task> funcToExecute, CancellationToken cancellationToken)
  {
    return Execute(funcToExecute, true, cancellationToken);
  }

  private async Task Execute(
    Func<CancellationToken, Task> funcToExecute,
    bool shouldBeExecutedInTransaction,
    CancellationToken cancellationToken)
  {
    if (_isExecuting)
    {
      await funcToExecute.Invoke(cancellationToken).ConfigureAwait(false);
    }
    else
    {
      _isExecuting = true;

      if (shouldBeExecutedInTransaction)
      {
        async Task<object?> CallbackAsync(
          IClientSessionHandle clientSessionHandle,
          CancellationToken cancellationToken)
        {
          await funcToExecute.Invoke(cancellationToken).ConfigureAwait(false);

          return Task.FromResult<object?>(null);
        }

        var task = _clientSessionHandle.WithTransactionAsync(CallbackAsync, cancellationToken: cancellationToken);

        await task.ConfigureAwait(false);
      }
      else
      {
        await funcToExecute.Invoke(cancellationToken).ConfigureAwait(false);
      }

      Reset();
    }
  }

  private void Reset()
  {
    _isExecuting = false;    
  }
}
