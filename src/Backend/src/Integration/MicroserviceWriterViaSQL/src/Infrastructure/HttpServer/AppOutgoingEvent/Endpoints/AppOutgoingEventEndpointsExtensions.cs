﻿namespace Makc.Dummy.Integration.MicroserviceWriterViaSQL.Infrastructure.HttpServer.AppOutgoingEvent.Endpoints;

/// <summary>
/// Расширения конечных точек исходящего события приложения.
/// </summary>
public static class AppOutgoingEventEndpointsExtensions
{
  /// <summary>
  /// Преобразовать к запросу действия по удалению исходящего события приложения.
  /// </summary>
  /// <param name="request">Запрос.</param>
  /// <returns>Запрос действия.</returns>
  public static AppOutgoingEventDeleteActionRequest ToAppOutgoingEventDeleteActionRequest(
    this AppOutgoingEventDeleteEndpointRequest request)
  {
    AppOutgoingEventDeleteCommand command = new(request.Id);

    return new(command);
  }

  /// <summary>
  /// Преобразовать к запросу действия по получению исходящего события приложения.
  /// </summary>
  /// <param name="request">Запрос.</param>
  /// <returns>Запрос действия.</returns>
  public static AppOutgoingEventGetActionRequest ToAppOutgoingEventGetActionRequest(
    this AppOutgoingEventGetEndpointRequest request)
  {
    AppOutgoingEventSingleQuery query = new(request.Id);

    return new(query);
  }

  /// <summary>
  /// Преобразовать к запросу действия по получению списка исходящих событий приложения.
  /// </summary>
  /// <param name="request">Запрос.</param>
  /// <returns>Запрос действия.</returns>
  public static AppOutgoingEventGetListActionRequest ToAppOutgoingEventGetListActionRequest(
    this AppOutgoingEventGetListEndpointRequest request)
  {
    AppOutgoingEventListQuery query = new(
      MaxCount: request.MaxCount,
      Sort: request.SortField.ToAppOutgoingEventQuerySortSection(request.SortIsDesc),
      Filter: new(FullTextSearchQuery: request.Query));

    return new(query);
  }

  /// <summary>
  /// Преобразовать к запросу действия по получению страницы исходящих событий приложения.
  /// </summary>
  /// <param name="request">Запрос.</param>
  /// <returns>Запрос действия.</returns>
  public static AppOutgoingEventGetPageActionRequest ToAppOutgoingEventGetPageActionRequest(
    this AppOutgoingEventGetPageEndpointRequest request)
  {
    AppOutgoingEventPageQuery query = new(
      Page: new(Number: request.CurrentPage, Size: request.ItemsPerPage),
      Sort: request.SortField.ToAppOutgoingEventQuerySortSection(request.SortIsDesc),
      Filter: new(FullTextSearchQuery: request.Query));

    return new(query);
  }

  /// <summary>
  /// Преобразовать к запросу действия по сохранению исходящего события приложения.
  /// </summary>
  /// <param name="request">Запрос.</param>
  /// <returns>Запрос действия.</returns>
  public static AppOutgoingEventSaveActionRequest ToAppOutgoingEventSaveActionRequest(
    this AppOutgoingEventCreateEndpointRequest request)
  {
    AppOutgoingEventSaveCommand command = new(
      IsUpdate: false,
      Id: 0,
      Data: new(Name: request.Name, PublishedAt: request.PublishedAt));

    return new(command);
  }

  /// <summary>
  /// Преобразовать к запросу действия по сохранению исходящего события приложения.
  /// </summary>
  /// <param name="request">Запрос.</param>
  /// <returns>Запрос действия.</returns>
  public static AppOutgoingEventSaveActionRequest ToAppOutgoingEventSaveActionRequest(
    this AppOutgoingEventUpdateEndpointRequest request)
  {
    AppOutgoingEventSaveCommand command = new(
      IsUpdate: true,
      Id: request.Id,
      Data: new(Name: request.Name, PublishedAt: request.PublishedAt));

    return new(command);
  }
}
