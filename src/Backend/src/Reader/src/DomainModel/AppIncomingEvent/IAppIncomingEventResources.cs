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
  /// Получить сообщение об ошибке пустого идентификатора события.
  /// </summary>
  /// <returns>Сообщение об ошибке.</returns>
  string GetEventIdIsEmptyErrorMessage();

  /// <summary>
  /// Получить сообщение об ошибке слишком длинного идентификатора события.
  /// </summary>
  /// <param name="maxLength">Максимальная длина.</param>
  /// <returns>Сообщение об ошибке.</returns>
  string GetEventIdIsTooLongErrorMessage(int maxLength);

  /// <summary>
  /// Получить сообщение об ошибке пустого имени события.
  /// </summary>
  /// <returns>Сообщение об ошибке.</returns>
  string GetEventNameIsEmptyErrorMessage();

  /// <summary>
  /// Получить сообщение об ошибке слишком длинного имени события.
  /// </summary>
  /// <param name="maxLength">Максимальная длина.</param>
  /// <returns>Сообщение об ошибке.</returns>
  string GetEventNameIsTooLongErrorMessage(int maxLength);

  /// <summary>
  /// Получить сообщение об ошибке недействительной даты загрузки.
  /// </summary>
  /// <returns>Сообщение об ошибке.</returns>
  string GetLoadedAtIsInvalidErrorMessage();

  /// <summary>
  /// Получить сообщение об ошибке недействительной даты обработки.
  /// </summary>
  /// <returns>Сообщение об ошибке.</returns>
  string GetProcessedAtIsInvalidErrorMessage();
}
