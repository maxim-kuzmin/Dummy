﻿namespace Makc.Dummy.Integration.MicroserviceReaderViaNoSQL.Domain.UseCases.AppIncomingEvent.Command.Sections;

/// <summary>
/// Раздел данных команды входящего события приложения.
/// </summary>
/// <param name="EventId">Идентификатор события.</param>
/// <param name="EventName">Имя события.</param>
/// <param name="LastLoadingAt">Последняя дата загрузки.</param>
/// <param name="LastLoadingError">Последняя ошибка загрузки.</param>
/// <param name="LastProcessingAt">Последняя дата обработки.</param>
/// <param name="LastProcessingError">Последняя ошибка обработки.</param>
/// <param name="LoadedAt">Дата загрузки.</param>
/// <param name="PayloadCount">Количество полезной нагрузки.</param>
/// <param name="PayloadTotalCount">Общее количество полезной нагрузки.</param>
/// <param name="ProcessedAt">Дата обработки.</param>
public record AppIncomingEventCommandDataSection(
  string EventId,
  string EventName,
  DateTimeOffset? LastLoadingAt,
  string? LastLoadingError,
  DateTimeOffset? LastProcessingAt,
  string? LastProcessingError,
  DateTimeOffset? LoadedAt,
  long PayloadCount,
  long PayloadTotalCount,
  DateTimeOffset? ProcessedAt);
