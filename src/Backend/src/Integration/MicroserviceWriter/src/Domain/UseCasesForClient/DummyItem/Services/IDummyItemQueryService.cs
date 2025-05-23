namespace Makc.Dummy.Integration.MicroserviceWriter.Domain.UseCasesForClient.DummyItem.Services;

/// <summary>
/// Интерфейс сервиса запросов фиктивного предмета.
/// </summary>
public interface IDummyItemQueryService
{
  /// <summary>
  /// Получить страницу объектов.
  /// </summary>
  /// <param name="query">Запрос.</param>
  /// <param name="cancellationToken">Токен отмены.</param>
  /// <returns>Результат.</returns>
  Task<Result<DummyItemPageDTO>> GetPage(
    DummyItemPageQuery query,
    CancellationToken cancellationToken);

  /// <summary>
  /// Получить единственный объект.
  /// </summary>
  /// <param name="query">Запрос.</param>
  /// <param name="cancellationToken">Токен отмены.</param>
  /// <returns>Результат.</returns>
  Task<Result<DummyItemSingleDTO>> GetSingle(
    DummyItemSingleQuery query,
    CancellationToken cancellationToken);
}
