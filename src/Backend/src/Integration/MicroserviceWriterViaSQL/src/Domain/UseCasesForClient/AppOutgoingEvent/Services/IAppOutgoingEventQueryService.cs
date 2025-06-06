﻿namespace Makc.Dummy.Integration.MicroserviceWriterViaSQL.Domain.UseCasesForClient.AppOutgoingEvent.Services;

/// <summary>
/// Интерфейс сервиса запросов исходящего события приложения.
/// </summary>
public interface IAppOutgoingEventQueryService
{
  /// <summary>
  /// Получить список объектов.
  /// </summary>
  /// <param name="query">Запрос.</param>
  /// <param name="cancellationToken">Токен отмены.</param>
  /// <returns>Результат.</returns>
  Task<Result<List<AppOutgoingEventSingleDTO>>> GetList(
    AppOutgoingEventListQuery query,
    CancellationToken cancellationToken);

  /// <summary>
  /// Получить страницу объектов.
  /// </summary>
  /// <param name="query">Запрос.</param>
  /// <param name="cancellationToken">Токен отмены.</param>
  /// <returns>Результат.</returns>
  Task<Result<AppOutgoingEventPageDTO>> GetPage(
    AppOutgoingEventPageQuery query,
    CancellationToken cancellationToken);

  /// <summary>
  /// Получить единственный объект.
  /// </summary>
  /// <param name="query">Запрос.</param>
  /// <param name="cancellationToken">Токен отмены.</param>
  /// <returns>Результат.</returns>
  Task<Result<AppOutgoingEventSingleDTO>> GetSingle(
    AppOutgoingEventSingleQuery query,
    CancellationToken cancellationToken);
}
