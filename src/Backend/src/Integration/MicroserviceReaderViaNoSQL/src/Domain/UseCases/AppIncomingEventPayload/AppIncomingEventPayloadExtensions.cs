﻿namespace Makc.Dummy.Integration.MicroserviceReaderViaNoSQL.Domain.UseCases.AppIncomingEventPayload;

/// <summary>
/// Расширения полезной нагрузки входящего события приложения.
/// </summary>
public static class AppIncomingEventPayloadExtensions
{
  /// <summary>
  /// Преобразовать к объекту передачи данных страницы полезных нагрузок входящего события приложения.
  /// </summary>
  /// <param name="items">Элементы.</param>
  /// <param name="totalCount">Общее количество.</param>
  /// <returns>Объект передачи данных.</returns>
  public static AppIncomingEventPayloadPageDTO ToAppIncomingEventPayloadPageDTO(
    this List<AppIncomingEventPayloadSingleDTO> items,
    long totalCount)
  {
    return new(Items: items, TotalCount: totalCount);
  }

  /// <summary>
  /// Преобразовать к разделу сортировки в запросе полезных нагрузок входящего события приложения.
  /// </summary>
  /// <param name="field">Поле сортировки.</param>
  /// <param name="isDesc">Сортировать по убыванию?</param>
  /// <returns>Pаздел сортировки в запросе.</returns>
  public static QuerySortSection ToAppIncomingEventPayloadQuerySortSection(this string? field, bool? isDesc)
  {
    field = (field ?? string.Empty).Trim();

    if (field == string.Empty)
    {
      field = AppIncomingEventPayloadSettings.DefaultQuerySortSection.Field;
    }

    return new(Field: field, IsDesc: isDesc ?? AppIncomingEventPayloadSettings.DefaultQuerySortSection.IsDesc);
  }
}
