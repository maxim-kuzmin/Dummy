namespace Makc.Dummy.Writer.DomainModel.AppOutgoingEventPayload;

/// <summary>
/// Интерфейс ресурсов нагрузки исходящего события приложения.
/// </summary>
public interface IAppOutgoingEventPayloadResources
{
  /// <summary>
  /// Получить сообщение об ошибке недействительного идентификатора исходящего события приложения.
  /// </summary>
  /// <returns>Сообщение об ошибке.</returns>
  string GetAppOutgoingEventIdIsInvalidErrorMessage();

  /// <summary>
  /// Получить сообщение об ошибке пустых данных.
  /// </summary>
  /// <returns>Сообщение об ошибке.</returns>
  string GetDataIsEmptyErrorMessage();

  /// <summary>
  /// Получить сообщение об ошибке слишком длинных данных.
  /// </summary>
  /// <param name="maxLength">Максимальная длина.</param>
  /// <returns>Сообщение об ошибке.</returns>
  string GetDataIsTooLongErrorMessage(int maxLength);
}
