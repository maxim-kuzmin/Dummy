namespace Makc.Dummy.Writer.DomainUseCases.AppEvent.Services;

/// <summary>
/// Интерфейс сервиса запросов события приложения.
/// </summary>
public interface IAppEventQueryService
{
  /// <summary>
  /// Подсчитать асинхронно.
  /// </summary>
  /// <param name="query">Запрос.</param>
  /// <param name="cancellationToken">Токен отмены.</param>
  /// <returns>Количество сущностей.</returns>
  Task<long> CountAsync(AppEventPageQuery query, CancellationToken cancellationToken);

  /// <summary>
  /// Получить асинхронно.
  /// </summary>
  /// <param name="query">Запрос.</param>
  /// <param name="cancellationToken">Токен отмены.</param>
  /// <returns>Объект передачи данных.</returns>
  Task<AppEventSingleDTO?> GetAsync(AppEventSingleQuery query, CancellationToken cancellationToken);

  /// <summary>
  /// Перечислить асинхронно.
  /// </summary>
  /// <param name="query">Запрос.</param>
  /// <param name="cancellationToken">Токен отмены.</param>
  /// <returns>Список объектов передачи данных.</returns>
  Task<List<AppEventSingleDTO>> ListAsync(AppEventListQuery query, CancellationToken cancellationToken);
}
