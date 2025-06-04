namespace Makc.Dummy.MicroserviceWriterViaSQL.Infrastructure.EntityFramework.AppOutgoingEvent;

/// <summary>
/// Репозиторий исходящего события приложения.
/// </summary>
/// <param name="appDbContext">Контекст базы данных приложения.</param>
public class AppOutgoingEventRepository(AppDbContext appDbContext) :
  AppRepositoryBase<AppOutgoingEventEntity>(appDbContext),
  IAppOutgoingEventRepository
{
  /// <inheritdoc/>
  public Task DeletePublished(AppOutgoingEventDeletePublishedCommand command, CancellationToken cancellationToken)
  {
    var query = AppDbContext.AppOutgoingEvent.Where(x => x.PublishedAt.HasValue);

    if (command.MaxDate.HasValue)
    {
      query = query.Where(x => x.PublishedAt < command.MaxDate.Value);
    }

    return query.ExecuteDeleteAsync(cancellationToken);
  }

  /// <inheritdoc/>
  public Task MarkAsPublished(AppOutgoingEventMarkAsPublishedCommand command, CancellationToken cancellationToken)
  {
    return AppDbContext.AppOutgoingEvent
      .Where(x => command.Ids.Contains(x.Id))
      .ExecuteUpdateAsync(x => x.SetProperty(xx => xx.PublishedAt, xx => command.PublishedAt), cancellationToken);
  }
}
