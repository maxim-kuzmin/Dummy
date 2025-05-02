namespace Makc.Dummy.Writer.Infrastructure.Grpc.AppOutgoingEventPayload;

/// <summary>
/// Расширения полезной нагрузки исходящего события приложения.
/// </summary>
public static class AppOutgoingEventPayloadExtensions
{
  public static AppOutgoingEventPayloadCreateActionCommand ToAppOutgoingEventPayloadCreateActionCommand(
    this AppOutgoingEventPayloadCreateActionRequest request)
  {
    AppEventPayloadWithDataAsString payload = new(request.Data)
    {
      EntityConcurrencyTokenToDelete = request.EntityConcurrencyTokenToDelete,
      EntityConcurrencyTokenToInsert = request.EntityConcurrencyTokenToInsert,
      EntityId = request.EntityId,
      EntityName = request.EntityName,      
      Position = request.Position
    };

    return new(request.AppOutgoingEventId, payload);
  }

  public static AppOutgoingEventPayloadDeleteActionCommand ToAppOutgoingEventPayloadDeleteActionCommand(
    this AppOutgoingEventPayloadDeleteActionRequest request)
  {
    return new(request.Id);
  }

  public static AppOutgoingEventPayloadGetActionQuery ToAppOutgoingEventPayloadGetActionQuery(this AppOutgoingEventPayloadGetActionRequest request)
  {
    return new()
    {
      Id = request.Id
    };
  }

  public static AppOutgoingEventPayloadGetActionReply ToAppOutgoingEventPayloadGetActionReply(this AppOutgoingEventPayloadSingleDTO dto)
  {
    return new()
    {
      Id = dto.Id,
      AppOutgoingEventId = dto.AppOutgoingEventId,
      Data = dto.Data,
      EntityConcurrencyTokenToDelete = dto.EntityConcurrencyTokenToDelete,
      EntityConcurrencyTokenToInsert = dto.EntityConcurrencyTokenToInsert,
      EntityId = dto.EntityId,
      EntityName = dto.EntityName,
      Position = dto.Position,
    };
  }

  public static AppOutgoingEventPayloadGetListActionQuery ToAppOutgoingEventPayloadGetListActionQuery(
    this AppOutgoingEventPayloadGetListActionRequest request)
  {
    AppOutgoingEventPayloadPageQuery pageQuery = new()
    {
      Page = new(request.Page.Number, request.Page.Size),
      Filter = new(request.Filter.FullTextSearchQuery)
    };

    return new(pageQuery)
    {
      Sort = new(request.Sort.Field, request.Sort.IsDesc)
    };
  }

  public static AppOutgoingEventPayloadGetListActionReply ToAppOutgoingEventPayloadGetListActionGrpcReply(this AppOutgoingEventPayloadListDTO dto)
  {
    AppOutgoingEventPayloadGetListActionReply result = new()
    {
      TotalCount = dto.TotalCount,
    };

    foreach (var itemDTO in dto.Items)
    {
      AppOutgoingEventPayloadGetListActionReplyItem item = new()
      {
        Id = itemDTO.Id,
        AppOutgoingEventId = itemDTO.AppOutgoingEventId,
        Data = itemDTO.Data,
        EntityConcurrencyTokenToDelete = itemDTO.EntityConcurrencyTokenToDelete,
        EntityConcurrencyTokenToInsert = itemDTO.EntityConcurrencyTokenToInsert,
        EntityId = itemDTO.EntityId,
        EntityName = itemDTO.EntityName,
        Position = itemDTO.Position,
      };

      result.Items.Add(item);
    }

    return result;
  }

  public static AppOutgoingEventPayloadUpdateActionCommand ToAppOutgoingEventPayloadUpdateActionCommand(
    this AppOutgoingEventPayloadUpdateActionRequest request)
  {
    AppEventPayloadWithDataAsString payload = new(request.Data)
    {
      EntityConcurrencyTokenToDelete = request.EntityConcurrencyTokenToDelete,
      EntityConcurrencyTokenToInsert = request.EntityConcurrencyTokenToInsert,
      EntityId = request.EntityId,
      EntityName = request.EntityName,
      Position = request.Position
    };

    return new(request.Id, request.AppOutgoingEventId, payload);
  }
}
