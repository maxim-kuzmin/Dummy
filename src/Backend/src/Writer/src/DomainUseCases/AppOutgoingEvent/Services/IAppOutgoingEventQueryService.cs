namespace Makc.Dummy.Writer.DomainUseCases.AppOutgoingEvent.Services;

/// <summary>
/// Интерфейс сервиса запросов исходящего события приложения.
/// </summary>
public interface IAppOutgoingEventQueryService
{
  /// <summary>
  /// Подсчитать асинхронно.
  /// </summary>
  /// <param name="query">Запрос.</param>
  /// <param name="cancellationToken">Токен отмены.</param>
  /// <returns>Количество сущностей.</returns>
  Task<long> CountAsync(AppOutgoingEventPageQuery query, CancellationToken cancellationToken);

  /// <summary>
  /// Получить асинхронно.
  /// </summary>
  /// <param name="query">Запрос.</param>
  /// <param name="cancellationToken">Токен отмены.</param>
  /// <returns>Объект передачи данных.</returns>
  Task<AppOutgoingEventSingleDTO?> GetAsync(AppOutgoingEventSingleQuery query, CancellationToken cancellationToken);

  /// <summary>
  /// Перечислить асинхронно.
  /// </summary>
  /// <param name="query">Запрос.</param>
  /// <param name="cancellationToken">Токен отмены.</param>
  /// <returns>Список объектов передачи данных.</returns>
  Task<List<AppOutgoingEventSingleDTO>> ListAsync(AppOutgoingEventListQuery query, CancellationToken cancellationToken);
}
