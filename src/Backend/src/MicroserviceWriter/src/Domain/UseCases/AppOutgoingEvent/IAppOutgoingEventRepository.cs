namespace Makc.Dummy.MicroserviceWriter.Domain.UseCases.AppOutgoingEvent;

/// <summary>
/// Интерфейс репозитория исходящего события приложения.
/// </summary>
public interface IAppOutgoingEventRepository : IReadRepository<AppOutgoingEventEntity>,
  IRepository<AppOutgoingEventEntity>
{
  /// <summary>
  /// Удалить опубликованное.
  /// </summary>
  /// <param name="command">Команда.</param>
  /// <param name="cancellationToken">Токен отмены.</param>
  /// <returns>Задача.</returns>
  Task DeletePublished(AppOutgoingEventDeletePublishedCommand command, CancellationToken cancellationToken);

  /// <summary>
  /// Пометить как опубликованное.
  /// </summary>
  /// <param name="command">Команда.</param>
  /// <param name="cancellationToken">Токен отмены.</param>
  /// <returns>Задача.</returns>
  Task MarkAsPublished(AppOutgoingEventMarkAsPublishedCommand command, CancellationToken cancellationToken);
}
