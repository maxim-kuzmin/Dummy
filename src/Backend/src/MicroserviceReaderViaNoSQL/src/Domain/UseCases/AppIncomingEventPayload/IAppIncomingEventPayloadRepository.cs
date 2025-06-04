namespace Makc.Dummy.MicroserviceReaderViaNoSQL.Domain.UseCases.AppIncomingEventPayload;

/// <summary>
/// Интерфейс репозитория полезной нагрузки входящего события приложения.
/// </summary>
public interface IAppIncomingEventPayloadRepository : IObjectRepository<AppIncomingEventPayloadEntity>
{
  /// <summary>
  /// Добавить не найденное по полезной нагрузке события.
  /// </summary>
  /// <param name="entities">Сущности.</param>
  /// <param name="cancellationToken">Токен отмены.</param>
  /// <returns>Задача.</returns>
  Task AddNotFoundByEventPayload(
    IEnumerable<AppIncomingEventPayloadEntity> entities,
    CancellationToken cancellationToken);

  /// <summary>
  /// Удалить список.
  /// </summary>
  /// <param name="command">Команда.</param>
  /// <param name="cancellationToken">Токен отмены.</param>
  /// <returns>Задача.</returns>
  Task DeleteList(AppIncomingEventPayloadDeleteListCommand command, CancellationToken cancellationToken);

  /// <summary>
  /// Получить количество сущностей.
  /// </summary>
  /// <param name="query">Запрос.</param>
  /// <param name="cancellationToken">Токен отмены.</param>
  /// <returns>Количество сущностей.</returns>
  Task<long> GetCount(AppIncomingEventPayloadCountQuery query, CancellationToken cancellationToken);

  /// <summary>
  /// Получить список сущностей.
  /// </summary>
  /// <param name="query">Запрос.</param>
  /// <param name="cancellationToken">Токен отмены.</param>
  /// <returns>Список сущностей.</returns>
  Task<List<AppIncomingEventPayloadEntity>> GetList(
    AppIncomingEventPayloadListQuery query,
    CancellationToken cancellationToken);

  /// <summary>
  /// Получить элементы страницы.
  /// </summary>
  /// <param name="query">Запрос.</param>
  /// <param name="cancellationToken">Токен отмены.</param>
  /// <returns>Список сущностей.</returns>
  Task<List<AppIncomingEventPayloadEntity>> GetPageItems(
    AppIncomingEventPayloadPageQuery query,
    CancellationToken cancellationToken);

  /// <summary>
  /// Получить единственную сущность.
  /// </summary>
  /// <param name="query">Запрос.</param>
  /// <param name="cancellationToken">Токен отмены.</param>
  /// <returns>Сущность.</returns>
  Task<AppIncomingEventPayloadEntity?> GetSingle(
    AppIncomingEventPayloadSingleQuery query,
    CancellationToken cancellationToken);
}

