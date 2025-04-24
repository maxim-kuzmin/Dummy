namespace Makc.Dummy.Writer.Infrastructure.Grpc.AppOutgoingEvent;

/// <summary>
/// Расширения исходящего события приложения.
/// </summary>
public static class AppOutgoingEventExtensions
{
  public static AppOutgoingEventCreateActionCommand ToAppOutgoingEventCreateActionCommand(
    this AppOutgoingEventCreateActionRequest request)
  {
    return new(request.IsPublished, request.Name);
  }

  public static AppOutgoingEventDeleteActionCommand ToAppOutgoingEventDeleteActionCommand(
    this AppOutgoingEventDeleteActionRequest request)
  {
    return new(request.Id);
  }

  public static AppOutgoingEventGetActionQuery ToAppOutgoingEventGetActionQuery(this AppOutgoingEventGetActionRequest request)
  {
    return new()
    {
      Id = request.Id
    };
  }

  public static AppOutgoingEventGetActionReply ToAppOutgoingEventGetActionReply(this AppOutgoingEventSingleDTO dto)
  {
    return new()
    {
      Id = dto.Id,
      CreatedAt = Timestamp.FromDateTimeOffset(dto.CreatedAt),
      IsPublished = dto.IsPublished,
      Name = dto.Name,
    };
  }

  public static AppOutgoingEventGetListActionQuery ToAppOutgoingEventGetListActionQuery(
    this AppOutgoingEventGetListActionRequest request)
  {
    AppOutgoingEventPageQuery pageQuery = new()
    {
      Page = new(request.Page.Number, request.Page.Size),
      Filter = new(request.Filter.FullTextSearchQuery)
    };

    return new(pageQuery)
    {
      Sort = new(request.Sort.Field, request.Sort.IsDesc)
    };
  }

  public static AppOutgoingEventGetListActionReply ToAppOutgoingEventGetListActionGrpcReply(this AppOutgoingEventListDTO dto)
  {
    AppOutgoingEventGetListActionReply result = new()
    {
      TotalCount = dto.TotalCount,
    };

    foreach (var itemDTO in dto.Items)
    {
      AppOutgoingEventGetListActionReplyItem item = new()
      {
        Id = itemDTO.Id,
        Name = itemDTO.Name,
      };

      result.Items.Add(item);
    }

    return result;
  }

  public static AppOutgoingEventUpdateActionCommand ToAppOutgoingEventUpdateActionCommand(
    this AppOutgoingEventUpdateActionRequest request)
  {
    return new(request.Id, request.IsPublished, request.Name);
  }
}
