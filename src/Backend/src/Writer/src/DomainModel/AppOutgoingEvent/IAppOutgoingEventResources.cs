namespace Makc.Dummy.Writer.DomainModel.AppOutgoingEvent;

/// <summary>
/// Интерфейс ресурсов исходящего события приложения.
/// </summary>
public interface IAppOutgoingEventResources
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
