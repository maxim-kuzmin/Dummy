namespace Makc.Dummy.Writer.Infrastructure.Grpc.AppEvent;

/// <summary>
/// Расширения события приложения.
/// </summary>
public static class AppEventExtensions
{
  public static AppEventCreateActionCommand ToAppEventCreateActionCommand(
    this AppEventCreateActionRequest request)
  {
    return new(request.IsPublished, request.Name);
  }

  public static AppEventDeleteActionCommand ToAppEventDeleteActionCommand(
    this AppEventDeleteActionRequest request)
  {
    return new(request.Id);
  }

  public static AppEventGetActionQuery ToAppEventGetActionQuery(this AppEventGetActionRequest request)
  {
    return new()
    {
      Id = request.Id
    };
  }

  public static AppEventGetActionReply ToAppEventGetActionReply(this AppEventSingleDTO dto)
  {
    return new()
    {
      Id = dto.Id,
      CreatedAt = Timestamp.FromDateTimeOffset(dto.CreatedAt),
      IsPublished = dto.IsPublished,
      Name = dto.Name,
    };
  }

  public static AppEventGetListActionQuery ToAppEventGetListActionQuery(
    this AppEventGetListActionRequest request)
  {
    AppEventPageQuery pageQuery = new()
    {
      Page = new QueryPageSection(request.Page.Number, request.Page.Size),
      Filter = new AppEventQueryFilterSection(request.Filter.FullTextSearchQuery)
    };

    return new(pageQuery)
    {
      Order = new QueryOrderSection(nameof(AppEventEntity.Id), true)
    };
  }

  public static AppEventGetListActionReply ToAppEventGetListActionGrpcReply(this AppEventListDTO dto)
  {
    AppEventGetListActionReply result = new()
    {
      TotalCount = dto.TotalCount,
    };

    foreach (var itemDTO in dto.Items)
    {
      AppEventGetListActionReplyItem item = new()
      {
        Id = itemDTO.Id,
        Name = itemDTO.Name,
      };

      result.Items.Add(item);
    }

    return result;
  }

  public static AppEventUpdateActionCommand ToAppEventUpdateActionCommand(
    this AppEventUpdateActionRequest request)
  {
    return new(request.Id, request.IsPublished, request.Name);
  }
}
