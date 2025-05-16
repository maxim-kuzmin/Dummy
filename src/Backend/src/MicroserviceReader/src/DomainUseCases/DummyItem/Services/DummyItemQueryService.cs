namespace Makc.Dummy.MicroserviceReader.DomainUseCases.DummyItem.Services;

/// <summary>
/// Сервис запросов фиктивного предмета.
/// </summary>
/// <param name="_repository">Репозиторий.</param>
public class DummyItemQueryService(IDummyItemRepository _repository) : IDummyItemQueryService
{
  /// <inheritdoc/>
  public Task<long> GetCount(DummyItemPageQuery query, CancellationToken cancellationToken)
  {
    return _repository.GetCount(query, cancellationToken);
  }

  /// <inheritdoc/>
  public async Task<List<DummyItemSingleDTO>> GetList(DummyItemListQuery query, CancellationToken cancellationToken)
  {
    var entities = await _repository.GetList(query, cancellationToken).ConfigureAwait(false);

    return [.. entities.Select(x =>  x.ToDummyItemSingleDTO())];
  }

  /// <inheritdoc/>
  public async Task<DummyItemSingleDTO?> GetSingle(DummyItemSingleQuery query, CancellationToken cancellationToken)
  {
    var entity = await _repository.GetSingle(query, cancellationToken).ConfigureAwait(false);

    return entity?.ToDummyItemSingleDTO();
  }
}
