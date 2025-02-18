namespace Makc.Dummy.Writer.Infrastructure.DapperForPostgreSQL.App.Db;

/// <summary>
/// Контекст базы данных приложения.
/// </summary>
/// <param name="_connectionString">Строка подключения.</param>
public class AppDbContext(string _connectionString) : DbContext, IAppDbContext
{
  /// <inheritdoc/>
  protected override IDbConnection CreateConnection()
  {
    return new NpgsqlConnection(_connectionString);
  }
}
