namespace Makc.Dummy.Reader.DomainModel.DummyItem;

/// <summary>
/// Интерфейс ресурсов фиктивного предмета.
/// </summary>
public interface IDummyItemResources
{
  /// <summary>
  /// Получить сообщение об ошибке пустого имени.
  /// </summary>
  /// <returns>Сообщение об ошибке.</returns>
  string GetNameIsEmptyErrorMessage();
}
