namespace Makc.Dummy.Reader.DomainModel.DummyItem;

/// <summary>
/// Интерфейс ресурсов фиктивного предмета.
/// </summary>
public interface IDummyItemResources
{
  /// <summary>
  /// Получить сообщение об ошибке недействительного токена параллелизма.
  /// </summary>
  /// <returns>Сообщение об ошибке.</returns>
  string GetConcurrencyTokenIsInvalidErrorMessage();

  /// <summary>
  /// Получить сообщение об ошибке недействительного идентификатора.
  /// </summary>
  /// <returns>Сообщение об ошибке.</returns>
  string GetIdIsInvalidErrorMessage();

  /// <summary>
  /// Получить сообщение об ошибке пустого имени.
  /// </summary>
  /// <returns>Сообщение об ошибке.</returns>
  string GetNameIsEmptyErrorMessage();
}
