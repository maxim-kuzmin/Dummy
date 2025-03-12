namespace Makc.Dummy.Gateway.Infrastructure.Http.DummyItem.Services;

/// <summary>
/// Сервис запросов фиктивного предмета.
/// </summary>
/// <param name="_appSession">Сессия приложения.</param>
/// <param name="_httpClientFactory">Фабрика клиентов HTTP.</param>
public class DummyItemQueryService(
  AppSession _appSession,
  IHttpClientFactory _httpClientFactory) : IDummyItemQueryService
{
  /// <inheritdoc/>
  public async Task<Result<DummyItemSingleDTO>> Get(
      DummyItemGetActionQuery query,
      CancellationToken cancellationToken)
  {
    using var httpClient = _httpClientFactory.CreateClient(AppSettings.WriterDummyItemClientName);

    var httpResponseTask = httpClient.GetAsync(query.ToHttpRequestUrl(), cancellationToken);

    using var httpResponse = await httpResponseTask.ConfigureAwait(false);

    var resultTask = httpResponse.ToResultFromJsonAsync<DummyItemSingleDTO>(cancellationToken);

    var result = await resultTask.ConfigureAwait(false);

    return result;
  }

  /// <inheritdoc/>
  public async Task<Result<DummyItemListDTO>> GetList(
      DummyItemGetListActionQuery query,
      CancellationToken cancellationToken)
  {
    using var httpClient = _httpClientFactory.CreateClient(AppSettings.WriterDummyItemClientName);

    using var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, query.ToHttpRequestUrl());

    httpRequestMessage.AddAuthorizationHeader(_appSession);

    var httpResponseTask = httpClient.SendAsync(httpRequestMessage, cancellationToken);

    using var httpResponse = await httpResponseTask.ConfigureAwait(false);

    var resultTask = httpResponse.ToResultFromJsonAsync<DummyItemListDTO>(cancellationToken);

    var result = await resultTask.ConfigureAwait(false);

    return result;
  }
}
