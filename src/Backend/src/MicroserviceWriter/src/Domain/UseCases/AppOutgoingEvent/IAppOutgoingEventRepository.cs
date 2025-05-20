namespace Makc.Dummy.MicroserviceWriter.Domain.UseCases.AppOutgoingEvent;

/// <summary>
/// Интерфейс репозитория исходящего события приложения.
/// </summary>
public interface IAppOutgoingEventRepository : IReadRepository<AppOutgoingEventEntity>,
  IRepository<AppOutgoingEventEntity>
{
  /// <summary>
  /// Обновить дату публикации.
  /// </summary>
  /// <param name="command">Команда.</param>
  /// <param name="cancellationToken">Токен отмены.</param>
  /// <returns>Задача.</returns>
  Task UpdatePublishedAt(
    AppOutgoingEventUpdatePropertyByIdsCommand<DateTimeOffset> command,
    CancellationToken cancellationToken);
}
