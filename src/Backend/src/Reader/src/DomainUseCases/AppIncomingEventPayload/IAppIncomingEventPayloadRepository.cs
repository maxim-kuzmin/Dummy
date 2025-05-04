namespace Makc.Dummy.Reader.DomainUseCases.AppIncomingEventPayload;

/// <summary>
/// Интерфейс репозитория полезной нагрузки входящего события приложения.
/// </summary>
public interface IAppIncomingEventPayloadRepository : IObjectRepository<AppIncomingEventPayloadEntity>
{
  /// <summary>
  /// Подсчитать асинхронно.
  /// </summary>
  /// <param name="query">Запрос.</param>
  /// <param name="cancellationToken">Токен отмены.</param>
  /// <returns>Количество сущностей.</returns>
  Task<long> CountAsync(AppIncomingEventPayloadPageQuery query, CancellationToken cancellationToken);

  /// <summary>
  /// Получить асинхронно.
  /// </summary>
  /// <param name="query">Запрос.</param>
  /// <param name="cancellationToken">Токен отмены.</param>
  /// <returns>Сущность.</returns>
  Task<AppIncomingEventPayloadEntity?> GetAsync(AppIncomingEventPayloadSingleQuery query, CancellationToken cancellationToken);

  /// <summary>
  /// Перечислить асинхронно.
  /// </summary>
  /// <param name="query">Запрос.</param>
  /// <param name="cancellationToken">Токен отмены.</param>
  /// <returns>Список сущностей.</returns>
  Task<List<AppIncomingEventPayloadEntity>> ListAsync(AppIncomingEventPayloadListQuery query, CancellationToken cancellationToken);
}

