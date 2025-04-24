namespace Makc.Dummy.Writer.DomainUseCases.AppOutgoingEventPayload.Services;

/// <summary>
/// Интерфейс сервиса запросов полезной нагрузки исходящего события приложения.
/// </summary>
public interface IAppOutgoingEventPayloadQueryService
{
  /// <summary>
  /// Подсчитать асинхронно.
  /// </summary>
  /// <param name="query">Запрос.</param>
  /// <param name="cancellationToken">Токен отмены.</param>
  /// <returns>Количество сущностей.</returns>
  Task<long> CountAsync(AppOutgoingEventPayloadPageQuery query, CancellationToken cancellationToken);

  /// <summary>
  /// Получить асинхронно.
  /// </summary>
  /// <param name="query">Запрос.</param>
  /// <param name="cancellationToken">Токен отмены.</param>
  /// <returns>Объект передачи данных.</returns>
  Task<AppOutgoingEventPayloadSingleDTO?> GetAsync(AppOutgoingEventPayloadSingleQuery query, CancellationToken cancellationToken);

  /// <summary>
  /// Перечислить асинхронно.
  /// </summary>
  /// <param name="query">Запрос.</param>
  /// <param name="cancellationToken">Токен отмены.</param>
  /// <returns>Список объектов передачи данных.</returns>
  Task<List<AppOutgoingEventPayloadSingleDTO>> ListAsync(AppOutgoingEventPayloadListQuery query, CancellationToken cancellationToken);
}
