namespace Makc.Dummy.MicroserviceWriter.Infrastructure.EntityFramework.AppOutgoingEvent;

/// <summary>
/// Репозиторий исходящего события приложения.
/// </summary>
/// <param name="appDbContext">Контекст базы данных приложения.</param>
public class AppOutgoingEventRepository(AppDbContext appDbContext) :
  AppRepositoryBase<AppOutgoingEventEntity>(appDbContext),
  IAppOutgoingEventRepository
{
  /// <inheritdoc/>
  public Task UpdatePublishedAt(
    AppOutgoingEventUpdatePropertyByIdsCommand<DateTimeOffset> command,
    CancellationToken cancellationToken)
  {
    return AppDbContext.AppOutgoingEvent
      .Where(x => command.Ids.Contains(x.Id))
      .ExecuteUpdateAsync(x => x.SetProperty(xx => xx.PublishedAt, xx => command.PropertyValue), cancellationToken);
  }
}
