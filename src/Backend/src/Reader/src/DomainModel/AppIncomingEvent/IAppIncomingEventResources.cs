namespace Makc.Dummy.Reader.DomainModel.AppIncomingEvent;

/// <summary>
/// Интерфейс ресурсов входящего события приложения.
/// </summary>
public interface IAppIncomingEventResources
{
  /// <summary>
  /// Получить сообщение об ошибке недействительной даты создания.
  /// </summary>
  /// <returns>Сообщение об ошибке.</returns>
  string GetCreatedAtIsInvalidErrorMessage();

  /// <summary>
  /// Получить сообщение об ошибке пустого имени.
  /// </summary>
  /// <returns>Сообщение об ошибке.</returns>
  string GetNameIsEmptyErrorMessage();

  /// <summary>
  /// Получить сообщение об ошибке слишком длинного имени.
  /// </summary>
  /// <param name="maxLength">Максимальная длина.</param>
  /// <returns>Сообщение об ошибке.</returns>
  string GetNameIsTooLongErrorMessage(int maxLength);
}
