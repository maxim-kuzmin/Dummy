namespace Makc.Dummy.Reader.DomainUseCases.DummyItem.Services;

/// <summary>
/// Интерфейс сервиса команд фиктивного предмета.
/// </summary>
public interface IDummyItemCommandService
{
  /// <summary>
  /// Обработчик изменения сущности.
  /// </summary>
  /// <param name="payload">Полезная нагрузка.</param>
  /// <param name="cancellationToken">Токен отмены.</param>
  /// <returns>Результат.</returns>
  Task<Result> OnEntityChanged(AppEventPayloadWithDataAsDictionary payload, CancellationToken cancellationToken);
}
