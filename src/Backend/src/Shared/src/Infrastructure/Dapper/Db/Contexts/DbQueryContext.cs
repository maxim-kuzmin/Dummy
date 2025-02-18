namespace Makc.Dummy.Shared.Infrastructure.Dapper.Db.Contexts;

/// <summary>
/// Контекст запросов базы данных.
/// </summary>
/// <typeparam name="TDbContext">Тип контекста базы данных.</typeparam>
/// <param name="_dbContext">Контекст базы данных.</param>
public abstract class DbQueryContext<TDbContext>(TDbContext _dbContext) : IDbQueryContext
  where TDbContext : IDbContext
{
  /// <inheritdoc/>
  public async Task<T?> GetFirstOrDefaultAsync<T>(DbCommand dbCommand, CancellationToken cancellationToken)
  {
    var query = await CreateQuery<T>(dbCommand).ConfigureAwait(false);

    return query.FirstOrDefault();
  }

  /// <inheritdoc/>
  public async Task<List<T>> GetListAsync<T>(DbCommand dbCommand, CancellationToken cancellationToken)
  {
    var query = await CreateQuery<T>(dbCommand).ConfigureAwait(false);

    return [.. query];
  }

  private Task<IEnumerable<T>> CreateQuery<T>(DbCommand dbCommand)
  {
    DynamicParameters parameters = new();

    foreach (var parameter in dbCommand.GetParameters())
    {
      parameters.Add(parameter.Key, parameter.Value);
    }
    
    return _dbContext.Connection.QueryAsync<T>(dbCommand.ToString(), parameters);
  }
}
