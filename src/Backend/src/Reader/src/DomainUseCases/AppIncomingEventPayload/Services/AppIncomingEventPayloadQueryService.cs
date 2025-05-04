namespace Makc.Dummy.Reader.DomainUseCases.AppIncomingEventPayload.Services;

/// <summary>
/// Сервис запросов полезной нагрузки входящего события приложения.
/// </summary>
/// <param name="_repository">Репозиторий.</param>
public class AppIncomingEventPayloadQueryService(
  IAppIncomingEventPayloadRepository _repository) : IAppIncomingEventPayloadQueryService
{
  /// <inheritdoc/>
  public Task<long> CountAsync(AppIncomingEventPayloadPageQuery query, CancellationToken cancellationToken)
  {
    return _repository.CountAsync(query, cancellationToken);
  }

  /// <inheritdoc/>
  public async Task<AppIncomingEventPayloadSingleDTO?> GetAsync(
    AppIncomingEventPayloadSingleQuery query,
    CancellationToken cancellationToken)
  {
    var entity = await _repository.GetAsync(query, cancellationToken).ConfigureAwait(false);

    return entity?.ToAppIncomingEventPayloadSingleDTO();
  }

  /// <inheritdoc/>
  public async Task<List<AppIncomingEventPayloadSingleDTO>> ListAsync(
    AppIncomingEventPayloadListQuery query,
    CancellationToken cancellationToken)
  {
    var entities = await _repository.ListAsync(query, cancellationToken).ConfigureAwait(false);

    return [.. entities.Select(x => x.ToAppIncomingEventPayloadSingleDTO())];
  }
}
