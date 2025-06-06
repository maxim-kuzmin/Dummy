﻿namespace Makc.Dummy.MicroserviceWriterViaSQL.Domain.UseCases.AppOutgoingEventPayload.Services;

/// <summary>
/// Интерфейс сервиса команд полезной нагрузки исходящего события приложения.
/// </summary>
public interface IAppOutgoingEventPayloadCommandService
{
  /// <summary>
  /// Удалить.
  /// </summary>
  /// <param name="command">Команда.</param>
  /// <param name="cancellationToken">Токен отмены.</param>
  /// <returns>Результат.</returns>
  Task<AppCommandResultWithoutValue> Delete(
    AppOutgoingEventPayloadDeleteCommand command,
    CancellationToken cancellationToken);

  /// <summary>
  /// Сохранить.
  /// </summary>
  /// <param name="command">Команда.</param>
  /// <param name="cancellationToken">Токен отмены.</param>
  /// <returns>Результат.</returns>
  Task<AppCommandResultWithValue<AppOutgoingEventPayloadSingleDTO>> Save(
    AppOutgoingEventPayloadSaveCommand command,
    CancellationToken cancellationToken);
}
