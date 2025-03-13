namespace Makc.Dummy.Reader.Infrastructure.MongoDB.DummyItem.Services;

public class DummyItemQueryService : IDummyItemQueryService
{
  public Task<long> CountAsync(DummyItemPageQuery query, CancellationToken cancellationToken)
  {
    throw new NotImplementedException();
  }

  public Task<DummyItemSingleDTO?> GetAsync(DummyItemSingleQuery query, CancellationToken cancellationToken)
  {
    throw new NotImplementedException();
  }

  public Task<List<DummyItemSingleDTO>> ListAsync(DummyItemListQuery query, CancellationToken cancellationToken)
  {
    throw new NotImplementedException();
  }
}
