﻿namespace Makc.Dummy.MicroserviceWriterViaSQL.Domain.Model.AppOutgoingEventPayload;

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
  /// Получить сообщение об ошибке слишком длинных данных.
  /// </summary>
  /// <param name="maxLength">Максимальная длина.</param>
  /// <returns>Сообщение об ошибке.</returns>
  string GetDataIsTooLongErrorMessage(int maxLength);

  /// <summary>
  /// Получить сообщение об ошибке слишком длинного токена параллелизма сущности для удаления.
  /// </summary>
  /// <param name="maxLength">Максимальная длина.</param>
  /// <returns>Сообщение об ошибке.</returns>
  string GetEntityConcurrencyTokenToDeleteIsTooLongErrorMessage(int maxLength);

  /// <summary>
  /// Получить сообщение об ошибке слишком длинного токена параллелизма сущности для вставки.
  /// </summary>
  /// <param name="maxLength">Максимальная длина.</param>
  /// <returns>Сообщение об ошибке.</returns>
  string GetEntityConcurrencyTokenToInsertIsTooLongErrorMessage(int maxLength);

  /// <summary>
  /// Получить сообщение об ошибке пустого идентификатора сущности.
  /// </summary>
  /// <returns>Сообщение об ошибке.</returns>
  string GetEntityIdIsEmptyErrorMessage();

  /// <summary>
  /// Получить сообщение об ошибке слишком длинного идентификатора сущности.
  /// </summary>
  /// <param name="maxLength">Максимальная длина.</param>
  /// <returns>Сообщение об ошибке.</returns>
  string GetEntityIdIsTooLongErrorMessage(int maxLength);

  /// <summary>
  /// Получить сообщение об ошибке пустого имени сущности.
  /// </summary>
  /// <returns>Сообщение об ошибке.</returns>
  string GetEntityNameIsEmptyErrorMessage();

  /// <summary>
  /// Получить сообщение об ошибке слишком длинного имени сущности.
  /// </summary>
  /// <param name="maxLength">Максимальная длина.</param>
  /// <returns>Сообщение об ошибке.</returns>
  string GetEntityNameIsTooLongErrorMessage(int maxLength);

  /// <summary>
  /// Получить сообщение об ошибке не являющейся положительным числом позиции.
  /// </summary>
  /// <returns>Сообщение об ошибке.</returns>
  string GetPositionIsNotPositiveNumberErrorMessage();
}
