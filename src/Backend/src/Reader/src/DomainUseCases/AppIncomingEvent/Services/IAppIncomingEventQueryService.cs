namespace Makc.Dummy.Reader.DomainUseCases.AppIncomingEvent.Services;

/// <summary>
/// Интерфейс сервиса запросов входящего события приложения.
/// </summary>
public interface IAppIncomingEventQueryService
{
  /// <summary>
  /// Подсчитать асинхронно.
  /// </summary>
  /// <param name="query">Запрос.</param>
  /// <param name="cancellationToken">Токен отмены.</param>
  /// <returns>Количество сущностей.</returns>
  Task<long> CountAsync(AppIncomingEventPageQuery query, CancellationToken cancellationToken);

  /// <summary>
  /// Получить асинхронно.
  /// </summary>
  /// <param name="query">Запрос.</param>
  /// <param name="cancellationToken">Токен отмены.</param>
  /// <returns>Объект передачи данных.</returns>
  Task<AppIncomingEventSingleDTO?> GetAsync(AppIncomingEventSingleQuery query, CancellationToken cancellationToken);

  /// <summary>
  /// Перечислить асинхронно.
  /// </summary>
  /// <param name="query">Запрос.</param>
  /// <param name="cancellationToken">Токен отмены.</param>
  /// <returns>Список объектов передачи данных.</returns>
  Task<List<AppIncomingEventSingleDTO>> ListAsync(AppIncomingEventListQuery query, CancellationToken cancellationToken);
}
