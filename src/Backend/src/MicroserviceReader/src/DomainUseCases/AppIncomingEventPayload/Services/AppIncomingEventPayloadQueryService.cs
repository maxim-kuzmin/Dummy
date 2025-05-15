namespace Makc.Dummy.MicroserviceReader.DomainUseCases.AppIncomingEventPayload.Services;

/// <summary>
/// Сервис запросов полезной нагрузки входящего события приложения.
/// </summary>
/// <param name="_repository">Репозиторий.</param>
public class AppIncomingEventPayloadQueryService(
  IAppIncomingEventPayloadRepository _repository) : IAppIncomingEventPayloadQueryService
{
  /// <inheritdoc/>
  public Task<long> GetCount(AppIncomingEventPayloadPageQuery query, CancellationToken cancellationToken)
  {
    return _repository.GetCount(query, cancellationToken);
  }

  /// <inheritdoc/>
  public async Task<AppIncomingEventPayloadSingleDTO?> GetSingle(
    AppIncomingEventPayloadSingleQuery query,
    CancellationToken cancellationToken)
  {
    var entity = await _repository.GetSingle(query, cancellationToken).ConfigureAwait(false);

    return entity?.ToAppIncomingEventPayloadSingleDTO();
  }

  /// <inheritdoc/>
  public async Task<List<AppIncomingEventPayloadSingleDTO>> GetList(
    AppIncomingEventPayloadListQuery query,
    CancellationToken cancellationToken)
  {
    var entities = await _repository.GetList(query, cancellationToken).ConfigureAwait(false);

    return [.. entities.Select(x => x.ToAppIncomingEventPayloadSingleDTO())];
  }
}
