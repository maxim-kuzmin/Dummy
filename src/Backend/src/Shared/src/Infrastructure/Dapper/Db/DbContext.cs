namespace Makc.Dummy.Shared.Infrastructure.Dapper.Db;

/// <summary>
/// Контекст базы данных.
/// </summary>
public abstract class DbContext : IDbContext
{
  private bool _disposedValue;

  /// <inheritdoc/>
  public IDbConnection Connection { get; }

  /// <summary>
  /// Конструктор.
  /// </summary>
  public DbContext()
  {
    Connection = CreateConnection();
  }

  // // TODO: override finalizer only if 'Dispose(bool disposing)' has code to free unmanaged resources
  // ~DbContext()
  // {
  //     // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
  //     Dispose(disposing: false);
  // }

  /// <inheritdoc/>
  public void Dispose()
  {
    // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
    Dispose(disposing: true);
    GC.SuppressFinalize(this);
  }

  /// <summary>
  /// Создать подключение.
  /// </summary>
  /// <returns>Подключение.</returns>
  protected abstract IDbConnection CreateConnection();

  /// <inheritdoc/>
  protected virtual void Dispose(bool disposing)
  {
    if (!_disposedValue)
    {
      if (disposing)
      {
        Connection.Dispose();
      }

      // TODO: free unmanaged resources (unmanaged objects) and override finalizer
      // TODO: set large fields to null
      _disposedValue = true;
    }
  }
}
