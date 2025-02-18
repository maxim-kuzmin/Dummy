namespace Makc.Dummy.Shared.Infrastructure.EntityFramework.Db.Contexts;

/// <summary>
/// Контекст запроса базы данных.
/// </summary>
/// <typeparam name="TDbContext">Тип контекста базы данных.</typeparam>
/// <param name="_dbContext">Контекст базы данных.</param>
public abstract class DbQueryContext<TDbContext>(TDbContext _dbContext) : IDbQueryContext
  where TDbContext : DbContext
{
  /// <inheritdoc/>
  public Task<T?> GetFirstOrDefaultAsync<T>(DbCommand dbCommand, CancellationToken cancellationToken)
  {
    return CreateQuery<T>(dbCommand).FirstOrDefaultAsync(cancellationToken);
  }

  /// <inheritdoc/>
  public Task<List<T>> GetListAsync<T>(DbCommand dbCommand, CancellationToken cancellationToken)
  {
    return CreateQuery<T>(dbCommand).ToListAsync(cancellationToken);
  }

  private IQueryable<T> CreateQuery<T>(DbCommand dbCommand)
  {
    var formattableStrting = dbCommand.ToFormattableString();

    return formattableStrting != null
      ? _dbContext.Database.SqlQuery<T>(formattableStrting)
      : _dbContext.Database.SqlQueryRaw<T>(dbCommand.ToString());
  }
}
