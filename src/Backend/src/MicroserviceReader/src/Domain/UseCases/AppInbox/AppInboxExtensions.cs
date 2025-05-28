using Makc.Dummy.Integration.MicroserviceWriter.Domain.UseCases.AppOutgoingEventPayload.DTOs;
using Makc.Dummy.Shared.Core.App.Event.Payloads;

namespace Makc.Dummy.MicroserviceReader.Domain.UseCases.AppInbox;

/// <summary>
/// Расширения входящих сообщений приложения.
/// </summary>
public static class AppInboxExtensions
{
  public static AppOutgoingEventPayloadGetPageActionRequest ToAppOutgoingEventPayloadGetPageActionRequest(
    this AppIncomingEventSingleDTO dto,
    int pageSize)
  {
    int pageNumber = dto.PayloadCount.ToPageNumber(pageSize);

    if (pageNumber > 1)
    {
      pageNumber++;
    }

    AppOutgoingEventPayloadPageQuery query = new(
      Page: new(Number: pageNumber, Size: pageSize),
      Sort: new(Field: AppOutgoingEventPayloadSettings.SortFieldForId, IsDesc: false),
      Filter: new(FullTextSearchQuery: null, AppOutgoingEventId: long.Parse(dto.EventId)));

    return new(query);
  }

  /// <summary>
  /// Преобразовать к разделу данных команды полезной нагрузки входящего события приложения.
  /// </summary>
  /// <param name="dto">Объект передачи данных.</param>
  /// <param name="appIncomingEventObjectId">Идентификатор объекта входящего события приложения.</param>
  /// <returns>Раздел данных команды полезной нагрузки входящего события приложения.</returns>
  public static AppIncomingEventPayloadCommandDataSection ToAppIncomingEventPayloadCommandDataSection(
    this AppOutgoingEventPayloadSingleDTO dto,
    string appIncomingEventObjectId
    )
  {
    AppEventPayloadWithDataAsString payload = new(dto.Data)
    {
      EntityId = dto.EntityId,
      EntityConcurrencyTokenToDelete = dto.EntityConcurrencyTokenToDelete,
      EntityConcurrencyTokenToInsert = dto.EntityConcurrencyTokenToInsert,
      EntityName = dto.EntityName,
      Position = dto.Position,
    };

    return new(
      AppIncomingEventObjectId: appIncomingEventObjectId,
      EventPayloadId: dto.Id.ToString(),
      Payload: payload);
  }
}
