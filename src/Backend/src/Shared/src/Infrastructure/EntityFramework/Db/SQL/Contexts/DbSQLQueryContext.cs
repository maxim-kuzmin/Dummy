namespace Makc.Dummy.Shared.Infrastructure.EntityFramework.Db.SQL.Contexts;

/// <summary>
/// Контекст запроса базы данных SQL.
/// </summary>
/// <typeparam name="TDbContext">Тип контекста базы данных.</typeparam>
/// <param name="_dbContext">Контекст базы данных.</param>
public abstract class DbSQLQueryContext<TDbContext>(TDbContext _dbContext) : IDbSQLQueryContext
  where TDbContext : DbContext
{
  /// <inheritdoc/>
  public Task<T?> GetFirstOrDefaultAsync<T>(DbSQLCommand dbCommand, CancellationToken cancellationToken)
  {
    return CreateQuery<T>(dbCommand).FirstOrDefaultAsync(cancellationToken);
  }

  /// <inheritdoc/>
  public Task<List<T>> GetListAsync<T>(DbSQLCommand dbCommand, CancellationToken cancellationToken)
  {
    return CreateQuery<T>(dbCommand).ToListAsync(cancellationToken);
  }

  private IQueryable<T> CreateQuery<T>(DbSQLCommand dbCommand)
  {
    var formattableStrting = dbCommand.ToFormattableString();

    return formattableStrting != null
      ? _dbContext.Database.SqlQuery<T>(formattableStrting)
      : _dbContext.Database.SqlQueryRaw<T>(dbCommand.ToString());
  }
}
