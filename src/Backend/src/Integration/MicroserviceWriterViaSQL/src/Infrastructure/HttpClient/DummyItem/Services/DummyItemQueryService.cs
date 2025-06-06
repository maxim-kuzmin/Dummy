﻿namespace Makc.Dummy.Integration.MicroserviceWriterViaSQL.Infrastructure.HttpClient.DummyItem.Services;

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
  public async Task<Result<List<DummyItemSingleDTO>>> GetList(
    DummyItemListQuery query,
    CancellationToken cancellationToken)
  {
    using var httpClient = _httpClientFactory.CreateClient(AppSettings.HttpClientName);

    using var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, query.ToHttpRequestUrl());

    httpRequestMessage.AddAuthorizationHeader(_appSession);

    var httpResponseTask = httpClient.SendAsync(httpRequestMessage, cancellationToken);

    using var httpResponse = await httpResponseTask.ConfigureAwait(false);

    var resultTask = httpResponse.ToResultFromJsonAsync<List<DummyItemSingleDTO>>(cancellationToken);

    var result = await resultTask.ConfigureAwait(false);

    return result;
  }

  /// <inheritdoc/>
  public async Task<Result<DummyItemPageDTO>> GetPage(
    DummyItemPageQuery query,
    CancellationToken cancellationToken)
  {
    using var httpClient = _httpClientFactory.CreateClient(AppSettings.HttpClientName);

    using var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, query.ToHttpRequestUrl());

    httpRequestMessage.AddAuthorizationHeader(_appSession);

    var httpResponseTask = httpClient.SendAsync(httpRequestMessage, cancellationToken);

    using var httpResponse = await httpResponseTask.ConfigureAwait(false);

    var resultTask = httpResponse.ToResultFromJsonAsync<DummyItemPageDTO>(cancellationToken);

    var result = await resultTask.ConfigureAwait(false);

    return result;
  }

  /// <inheritdoc/>
  public async Task<Result<DummyItemSingleDTO>> GetSingle(
    DummyItemSingleQuery query,
    CancellationToken cancellationToken)
  {
    using var httpClient = _httpClientFactory.CreateClient(AppSettings.HttpClientName);

    var httpResponseTask = httpClient.GetAsync(query.ToHttpRequestUrl(), cancellationToken);

    using var httpResponse = await httpResponseTask.ConfigureAwait(false);

    var resultTask = httpResponse.ToResultFromJsonAsync<DummyItemSingleDTO>(cancellationToken);

    var result = await resultTask.ConfigureAwait(false);

    return result;
  }
}
