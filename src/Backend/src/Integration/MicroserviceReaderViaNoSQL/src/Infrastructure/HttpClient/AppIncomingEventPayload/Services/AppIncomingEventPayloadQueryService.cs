namespace Makc.Dummy.Integration.MicroserviceReaderViaNoSQL.Infrastructure.HttpClient.AppIncomingEventPayload.Services;

/// <summary>
/// Сервис запросов полезной нагрузки входящего события приложения.
/// </summary>
/// <param name="_appSession">Сессия приложения.</param>
/// <param name="_httpClientFactory">Фабрика клиентов HTTP.</param>
public class AppIncomingEventPayloadQueryService(
  AppSession _appSession,
  IHttpClientFactory _httpClientFactory) : IAppIncomingEventPayloadQueryService
{
  /// <inheritdoc/>
  public async Task<Result<List<AppIncomingEventPayloadSingleDTO>>> GetList(
    AppIncomingEventPayloadListQuery query,
    CancellationToken cancellationToken)
  {
    using var httpClient = _httpClientFactory.CreateClient(AppSettings.HttpClientName);

    using var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, query.ToHttpRequestUrl());

    httpRequestMessage.AddAuthorizationHeader(_appSession);

    var httpResponseTask = httpClient.SendAsync(httpRequestMessage, cancellationToken);

    using var httpResponse = await httpResponseTask.ConfigureAwait(false);

    var resultTask = httpResponse.ToResultFromJsonAsync<List<AppIncomingEventPayloadSingleDTO>>(cancellationToken);

    var result = await resultTask.ConfigureAwait(false);

    return result;
  }

  /// <inheritdoc/>
  public async Task<Result<AppIncomingEventPayloadPageDTO>> GetPage(
    AppIncomingEventPayloadPageQuery query,
    CancellationToken cancellationToken)
  {
    using var httpClient = _httpClientFactory.CreateClient(AppSettings.HttpClientName);

    using var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, query.ToHttpRequestUrl());

    httpRequestMessage.AddAuthorizationHeader(_appSession);

    var httpResponseTask = httpClient.SendAsync(httpRequestMessage, cancellationToken);

    using var httpResponse = await httpResponseTask.ConfigureAwait(false);

    var resultTask = httpResponse.ToResultFromJsonAsync<AppIncomingEventPayloadPageDTO>(cancellationToken);

    var result = await resultTask.ConfigureAwait(false);

    return result;
  }

  /// <inheritdoc/>
  public async Task<Result<AppIncomingEventPayloadSingleDTO>> GetSingle(
    AppIncomingEventPayloadSingleQuery query,
    CancellationToken cancellationToken)
  {
    using var httpClient = _httpClientFactory.CreateClient(AppSettings.HttpClientName);

    var httpResponseTask = httpClient.GetAsync(query.ToHttpRequestUrl(), cancellationToken);

    using var httpResponse = await httpResponseTask.ConfigureAwait(false);

    var resultTask = httpResponse.ToResultFromJsonAsync<AppIncomingEventPayloadSingleDTO>(cancellationToken);

    var result = await resultTask.ConfigureAwait(false);

    return result;
  }
}
