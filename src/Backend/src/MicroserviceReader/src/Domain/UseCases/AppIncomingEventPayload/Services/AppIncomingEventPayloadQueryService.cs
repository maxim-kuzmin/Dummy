namespace Makc.Dummy.MicroserviceReader.Domain.UseCases.AppIncomingEventPayload.Services;

/// <summary>
/// Сервис запросов полезной нагрузки входящего события приложения.
/// </summary>
/// <param name="_repository">Репозиторий.</param>
public class AppIncomingEventPayloadQueryService(
  IAppIncomingEventPayloadRepository _repository) : IAppIncomingEventPayloadQueryService
{
  /// <inheritdoc/>
  public Task<AppIncomingEventPayloadListDTO> Download(
    AppIncomingEventPayloadDownloadQuery query,
    CancellationToken cancellationToken)
  {
    throw new NotImplementedException();
  }

  /// <inheritdoc/>
  public Task<long> GetCount(AppIncomingEventPayloadCountQuery query, CancellationToken cancellationToken)
  {
    return _repository.GetCount(query, cancellationToken);
  }

  /// <inheritdoc/>
  public async Task<List<AppIncomingEventPayloadSingleDTO>> GetList(
    AppIncomingEventPayloadListQuery query,
    CancellationToken cancellationToken)
  {
    var entities = await _repository.GetList(query, cancellationToken).ConfigureAwait(false);

    return [.. entities.Select(x => x.ToAppIncomingEventPayloadSingleDTO())];
  }

  /// <inheritdoc/>
  public async Task<AppIncomingEventPayloadListDTO> GetPage(
    AppIncomingEventPayloadPageQuery query,
    CancellationToken cancellationToken)
  {
    var totalCount = await GetCount(query, cancellationToken).ConfigureAwait(false);

    List<AppIncomingEventPayloadSingleDTO> items;

    if (totalCount > 0)
    {
      var entities = await _repository.GetPageItems(query, cancellationToken).ConfigureAwait(false);

      items = [.. entities.Select(x => x.ToAppIncomingEventPayloadSingleDTO())];
    }
    else
    {
      items = [];
    }

    return items.ToAppIncomingEventPayloadListDTO(totalCount);
  }

  /// <inheritdoc/>
  public async Task<AppIncomingEventPayloadSingleDTO?> GetSingle(
    AppIncomingEventPayloadSingleQuery query,
    CancellationToken cancellationToken)
  {
    var entity = await _repository.GetSingle(query, cancellationToken).ConfigureAwait(false);

    return entity?.ToAppIncomingEventPayloadSingleDTO();
  }
}
