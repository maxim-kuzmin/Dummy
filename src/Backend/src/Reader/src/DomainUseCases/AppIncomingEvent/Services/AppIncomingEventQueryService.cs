namespace Makc.Dummy.Reader.DomainUseCases.AppIncomingEvent.Services;

/// <summary>
/// Сервис запросов входящего события приложения.
/// </summary>
/// <param name="_repository">Репозиторий.</param>
public class AppIncomingEventQueryService(
  IAppIncomingEventEntityRepository _repository) : IAppIncomingEventQueryService
{
  /// <inheritdoc/>
  public Task<long> CountAsync(AppIncomingEventPageQuery query, CancellationToken cancellationToken)
  {
    return _repository.CountAsync(query, cancellationToken);
  }

  /// <inheritdoc/>
  public async Task<AppIncomingEventSingleDTO?> GetAsync(
    AppIncomingEventSingleQuery query,
    CancellationToken cancellationToken)
  {
    var entity = await _repository.GetAsync(query, cancellationToken).ConfigureAwait(false);

    return entity?.ToAppIncomingEventSingleDTO();
  }

  /// <inheritdoc/>
  public async Task<List<AppIncomingEventSingleDTO>> ListAsync(
    AppIncomingEventListQuery query,
    CancellationToken cancellationToken)
  {
    var entities = await _repository.ListAsync(query, cancellationToken).ConfigureAwait(false);

    return [.. entities.Select(x => x.ToAppIncomingEventSingleDTO())];
  }
}
