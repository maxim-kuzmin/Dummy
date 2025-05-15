namespace Makc.Dummy.MicroserviceReader.DomainUseCases.AppIncomingEvent.Services;

/// <summary>
/// Сервис запросов входящего события приложения.
/// </summary>
/// <param name="_repository">Репозиторий.</param>
public class AppIncomingEventQueryService(
  IAppIncomingEventRepository _repository) : IAppIncomingEventQueryService
{
  /// <inheritdoc/>
  public Task<long> GetCount(AppIncomingEventPageQuery query, CancellationToken cancellationToken)
  {
    return _repository.GetCount(query, cancellationToken);
  }

  /// <inheritdoc/>
  public async Task<AppIncomingEventSingleDTO?> GetSingle(
    AppIncomingEventSingleQuery query,
    CancellationToken cancellationToken)
  {
    var entity = await _repository.GetSingle(query, cancellationToken).ConfigureAwait(false);

    return entity?.ToAppIncomingEventSingleDTO();
  }

  /// <inheritdoc/>
  public async Task<List<AppIncomingEventSingleDTO>> GetList(
    AppIncomingEventListQuery query,
    CancellationToken cancellationToken)
  {
    var entities = await _repository.GetList(query, cancellationToken).ConfigureAwait(false);

    return [.. entities.Select(x => x.ToAppIncomingEventSingleDTO())];
  }
}
