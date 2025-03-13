﻿namespace Makc.Dummy.Writer.Apps.WebApp.AppEventPayload.Endpoints.GetList;

/// <summary>
/// Запрос конечной точки получения списка полезных нагрузок события приложения.
/// </summary>
/// <param name="CurrentPage">Текущая страница.</param>
/// <param name="ItemsPerPage">Количество записей на странице.</param>
/// <param name="OrderField">Поле сортировки.</param>
/// <param name="OrderIsDesc">Сортировка по убыванию?</param>
/// <param name="Query">Запрос.</param>
public record AppEventPayloadGetListEndpointRequest(
  int CurrentPage,
  int ItemsPerPage,
  string? OrderField,
  bool? OrderIsDesc,
  string? Query);
