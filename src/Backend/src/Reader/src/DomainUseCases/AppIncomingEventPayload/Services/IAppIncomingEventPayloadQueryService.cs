namespace Makc.Dummy.Reader.DomainUseCases.AppIncomingEventPayload.Services;

/// <summary>
/// Интерфейс сервиса запросов полезной нагрузки входящего события приложения.
/// </summary>
public interface IAppIncomingEventPayloadQueryService
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
  /// <returns>Объект передачи данных.</returns>
  Task<AppIncomingEventPayloadSingleDTO?> GetAsync(AppIncomingEventPayloadSingleQuery query, CancellationToken cancellationToken);

  /// <summary>
  /// Перечислить асинхронно.
  /// </summary>
  /// <param name="query">Запрос.</param>
  /// <param name="cancellationToken">Токен отмены.</param>
  /// <returns>Список объектов передачи данных.</returns>
  Task<List<AppIncomingEventPayloadSingleDTO>> ListAsync(AppIncomingEventPayloadListQuery query, CancellationToken cancellationToken);
}
