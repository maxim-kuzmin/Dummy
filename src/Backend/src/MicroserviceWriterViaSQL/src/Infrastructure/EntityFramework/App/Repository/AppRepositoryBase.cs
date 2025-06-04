namespace Makc.Dummy.MicroserviceWriterViaSQL.Infrastructure.EntityFramework.App.Repository;

/// <summary>
/// Основа репозитория приложения.
/// </summary>
/// <typeparam name="TAggregateRoot">Тип корня агрегата.</typeparam>
/// <param name="appDbContext">Контекст базы данных приложения.</param>
public class AppRepositoryBase<TAggregateRoot>(AppDbContext appDbContext) :
  RepositoryBase<TAggregateRoot>(appDbContext),
  IReadRepository<TAggregateRoot>,
  IRepository<TAggregateRoot>
  where TAggregateRoot : class, IAggregateRoot
{
  /// <summary>
  /// Контекст базы данных приложения.
  /// </summary>
  protected AppDbContext AppDbContext => appDbContext;
}
