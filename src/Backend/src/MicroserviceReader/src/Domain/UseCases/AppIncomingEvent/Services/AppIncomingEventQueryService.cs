namespace Makc.Dummy.MicroserviceReader.Domain.UseCases.AppIncomingEvent.Services;

/// <summary>
/// Сервис запросов входящего события приложения.
/// </summary>
/// <param name="_repository">Репозиторий.</param>
public class AppIncomingEventQueryService(
  IAppIncomingEventRepository _repository) : IAppIncomingEventQueryService
{
  /// <inheritdoc/>
  public Task<long> GetCount(AppIncomingEventCountQuery query, CancellationToken cancellationToken)
  {
    return _repository.GetCount(query, cancellationToken);
  }

  /// <inheritdoc/>
  public async Task<List<AppIncomingEventSingleDTO>> GetList(
    AppIncomingEventListQuery query,
    CancellationToken cancellationToken)
  {
    var entities = await _repository.GetList(query, cancellationToken).ConfigureAwait(false);

    return [.. entities.Select(x => x.ToAppIncomingEventSingleDTO())];
  }

  /// <inheritdoc/>
  public async Task<AppIncomingEventListDTO> GetPage(
    AppIncomingEventPageQuery query,
    CancellationToken cancellationToken)
  {
    var totalCount = await GetCount(query, cancellationToken).ConfigureAwait(false);

    List<AppIncomingEventSingleDTO> items;

    if (totalCount > 0)
    {
      var entities = await _repository.GetPageItems(query, cancellationToken).ConfigureAwait(false);

      items = [.. entities.Select(x => x.ToAppIncomingEventSingleDTO())];
    }
    else
    {
      items = [];
    }

    return items.ToAppIncomingEventListDTO(totalCount);
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
  public async Task<List<AppIncomingEventSingleDTO>> GetUnloadedList(
    AppIncomingEventUnloadedListQuery query,
    CancellationToken cancellationToken)
  {
    var entities = await _repository.GetUnloadedList(query, cancellationToken).ConfigureAwait(false);

    return [.. entities.Select(x => x.ToAppIncomingEventSingleDTO())];
  }
}
