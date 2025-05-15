namespace Makc.Dummy.MicroserviceReader.DomainModel.AppIncomingEvent;

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
  /// Получить сообщение об ошибке недействительной последней даты загрузки.
  /// </summary>
  /// <returns>Сообщение об ошибке.</returns>
  string GetLastLoadingAtIsInvalidErrorMessage();

  /// <summary>
  /// Получить сообщение об ошибке слишком длинной последней ошибки загрузки.
  /// </summary>
  /// <param name="maxLength">Максимальная длина.</param>
  /// <returns>Сообщение об ошибке.</returns>
  string GetLastLoadingErrorIsTooLongErrorMessage(int maxLength);

  /// <summary>
  /// Получить сообщение об ошибке недействительной даты загрузки.
  /// </summary>
  /// <returns>Сообщение об ошибке.</returns>
  string GetLoadedAtIsInvalidErrorMessage();

  /// <summary>
  /// Получить сообщение об ошибке отрицательного количества полезной загрузки.
  /// </summary>
  /// <returns>Сообщение об ошибке.</returns>
  string GetPayloadCountIsNegativeErrorMessage();

  /// <summary>
  /// Получить сообщение об ошибке отрицательного общего количества полезной загрузки.
  /// </summary>
  /// <returns>Сообщение об ошибке.</returns>
  string GetPayloadTotalCountIsNegativeErrorMessage();

  /// <summary>
  /// Получить сообщение об ошибке недействительной даты обработки.
  /// </summary>
  /// <returns>Сообщение об ошибке.</returns>
  string GetProcessedAtIsInvalidErrorMessage();
}
