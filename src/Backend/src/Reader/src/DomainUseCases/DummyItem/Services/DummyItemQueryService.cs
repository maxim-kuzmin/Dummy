namespace Makc.Dummy.Reader.DomainUseCases.DummyItem.Services;

/// <summary>
/// Сервис запросов фиктивного предмета.
/// </summary>
public class DummyItemQueryService(IDummyItemEntityRepository _repository) : IDummyItemQueryService
{
  /// <inheritdoc/>
  public Task<long> CountAsync(DummyItemPageQuery query, CancellationToken cancellationToken)
  {
    return _repository.CountAsync(query, cancellationToken);
  }

  /// <inheritdoc/>
  public async Task<DummyItemSingleDTO?> GetAsync(DummyItemSingleQuery query, CancellationToken cancellationToken)
  {
    var entity = await _repository.GetAsync(query, cancellationToken).ConfigureAwait(false);

    return entity?.ToDummyItemSingleDTO();
  }

  /// <inheritdoc/>
  public async Task<List<DummyItemSingleDTO>> ListAsync(DummyItemListQuery query, CancellationToken cancellationToken)
  {
    var entities = await _repository.ListAsync(query, cancellationToken).ConfigureAwait(false);

    return entities.Select(x =>  x.ToDummyItemSingleDTO()).ToList();
  }
}
