namespace Makc.Dummy.Shared.Infrastructure.Dapper.Db.Contexts;

/// <summary>
/// Контекст запросов базы данных.
/// </summary>
/// <typeparam name="TDbContext">Тип контекста базы данных.</typeparam>
/// <param name="_dbContext">Контекст базы данных.</param>
public abstract class DbQueryContext<TDbContext>(TDbContext _dbContext) : IDbSQLQueryContext
  where TDbContext : IDbContext
{
  /// <inheritdoc/>
  public async Task<T?> GetFirstOrDefault<T>(DbSQLCommand dbCommand, CancellationToken cancellationToken)
  {
    var result = await Execute<T>(dbCommand).ConfigureAwait(false);

    return result.FirstOrDefault();
  }

  /// <inheritdoc/>
  public async Task<List<T>> GetList<T>(DbSQLCommand dbCommand, CancellationToken cancellationToken)
  {
    var result = await Execute<T>(dbCommand).ConfigureAwait(false);

    return [.. result];
  }

  private Task<IEnumerable<T>> Execute<T>(DbSQLCommand dbCommand)
  {
    DynamicParameters parameters = new();

    foreach (var parameter in dbCommand.GetParameters())
    {
      parameters.Add(parameter.Key, parameter.Value);
    }
    
    return _dbContext.Connection.QueryAsync<T>(dbCommand.ToString(), parameters);
  }
}
