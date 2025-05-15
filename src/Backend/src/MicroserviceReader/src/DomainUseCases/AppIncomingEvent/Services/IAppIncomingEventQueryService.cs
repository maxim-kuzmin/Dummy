namespace Makc.Dummy.MicroserviceReader.DomainUseCases.AppIncomingEvent.Services;

/// <summary>
/// Интерфейс сервиса запросов входящего события приложения.
/// </summary>
public interface IAppIncomingEventQueryService
{
  /// <summary>
  /// Получить количество сущностей.
  /// </summary>
  /// <param name="query">Запрос.</param>
  /// <param name="cancellationToken">Токен отмены.</param>
  /// <returns>Количество сущностей.</returns>
  Task<long> GetCount(AppIncomingEventPageQuery query, CancellationToken cancellationToken);

  /// <summary>
  /// Получить единственную сущность.
  /// </summary>
  /// <param name="query">Запрос.</param>
  /// <param name="cancellationToken">Токен отмены.</param>
  /// <returns>Сущность.</returns>
  Task<AppIncomingEventSingleDTO?> GetSingle(AppIncomingEventSingleQuery query, CancellationToken cancellationToken);

  /// <summary>
  /// Получить список сущностей.
  /// </summary>
  /// <param name="query">Запрос.</param>
  /// <param name="cancellationToken">Токен отмены.</param>
  /// <returns>Список сущностей.</returns>
  Task<List<AppIncomingEventSingleDTO>> GetList(AppIncomingEventListQuery query, CancellationToken cancellationToken);

  /// <summary>
  /// Получить список незагруженных сущностей.
  /// </summary>
  /// <param name="query">Запрос.</param>
  /// <param name="cancellationToken">Токен отмены.</param>
  /// <returns>Список сущностей.</returns>
  Task<List<AppIncomingEventSingleDTO>> GetUnloadedList(
      AppIncomingEventUnloadedListQuery query,
      CancellationToken cancellationToken);
}
