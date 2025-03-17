namespace Makc.Dummy.Reader.Infrastructure.Grpc.DummyItem;

/// <summary>
/// Расширения фиктивного предмета.
/// </summary>
public static class DummyItemExtensions
{
  public static DummyItemCreateActionCommand ToDummyItemCreateActionCommand(
    this DummyItemCreateActionRequest request)
  {
    return new(request.Name);
  }

  public static DummyItemDeleteActionCommand ToDummyItemDeleteActionCommand(
    this DummyItemDeleteActionRequest request)
  {
    return new(request.ObjectId);
  }

  public static DummyItemGetActionQuery ToDummyItemGetActionQuery(this DummyItemGetActionRequest request)
  {
    return new()
    {
      ObjectId = request.ObjectId
    };
  }

  public static DummyItemGetActionReply ToDummyItemGetActionReply(this DummyItemSingleDTO dto)
  {
    return new()
    {
      ObjectId = dto.ObjectId,
      Name = dto.Name,
    };
  }

  public static DummyItemGetListActionQuery ToDummyItemGetListActionQuery(
    this DummyItemGetListActionRequest request)
  {
    DummyItemPageQuery pageQuery = new()
    {
      Page = new(request.Page.Number, request.Page.Size),
      Filter = new(request.Filter.FullTextSearchQuery)
    };

    return new(pageQuery)
    {
      Sort = DummyItemSettings.DefaultQuerySortSection
    };
  }

  public static DummyItemGetListActionReply ToDummyItemGetListActionGrpcReply(this DummyItemListDTO dto)
  {
    DummyItemGetListActionReply result = new()
    {
      TotalCount = dto.TotalCount,
    };

    foreach (var itemDTO in dto.Items)
    {
      DummyItemGetListActionReplyItem item = new()
      {
        ObjectId = itemDTO.ObjectId,
        Name = itemDTO.Name,
      };

      result.Items.Add(item);
    }

    return result;
  }

  public static DummyItemUpdateActionCommand ToDummyItemUpdateActionCommand(
    this DummyItemUpdateActionRequest request)
  {
    return new(request.ObjectId, request.Name);
  }
}
