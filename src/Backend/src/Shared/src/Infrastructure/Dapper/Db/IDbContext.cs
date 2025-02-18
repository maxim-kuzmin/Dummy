namespace Makc.Dummy.Shared.Infrastructure.Dapper.Db;

/// <summary>
/// Интерфейс контекста базы данных.
/// </summary>
public interface IDbContext : IDisposable
{
  /// <summary>
  /// Подключение.
  /// </summary>
  IDbConnection Connection { get; }
}
