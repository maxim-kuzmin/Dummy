namespace Makc.Dummy.Integration.MicroserviceWriter.Infrastructure.HttpClient.AppOutgoingEventPayload.Services;

/// <summary>
/// Сервис запросов полезной нагрузки исходящего события приложения.
/// </summary>
/// <param name="_appSession">Сессия приложения.</param>
/// <param name="_httpClientFactory">Фабрика клиентов HTTP.</param>
public class AppOutgoingEventPayloadQueryService(
  AppSession _appSession,
  IHttpClientFactory _httpClientFactory) : IAppOutgoingEventPayloadQueryService
{
  /// <inheritdoc/>
  public async Task<Result<List<AppOutgoingEventPayloadSingleDTO>>> GetList(
    AppOutgoingEventPayloadListQuery query,
    CancellationToken cancellationToken)
  {
    using var httpClient = _httpClientFactory.CreateClient(AppSettings.HttpClientName);

    using var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, query.ToHttpRequestUrl());

    httpRequestMessage.AddAuthorizationHeader(_appSession);

    var httpResponseTask = httpClient.SendAsync(httpRequestMessage, cancellationToken);

    using var httpResponse = await httpResponseTask.ConfigureAwait(false);

    var resultTask = httpResponse.ToResultFromJsonAsync<List<AppOutgoingEventPayloadSingleDTO>>(cancellationToken);

    var result = await resultTask.ConfigureAwait(false);

    return result;
  }

  /// <inheritdoc/>
  public async Task<Result<AppOutgoingEventPayloadPageDTO>> GetPage(
    AppOutgoingEventPayloadPageQuery query,
    CancellationToken cancellationToken)
  {
    using var httpClient = _httpClientFactory.CreateClient(AppSettings.HttpClientName);

    using var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, query.ToHttpRequestUrl());

    httpRequestMessage.AddAuthorizationHeader(_appSession);

    var httpResponseTask = httpClient.SendAsync(httpRequestMessage, cancellationToken);

    using var httpResponse = await httpResponseTask.ConfigureAwait(false);

    var resultTask = httpResponse.ToResultFromJsonAsync<AppOutgoingEventPayloadPageDTO>(cancellationToken);

    var result = await resultTask.ConfigureAwait(false);

    return result;
  }


  /// <inheritdoc/>
  public async Task<Result<AppOutgoingEventPayloadSingleDTO>> GetSingle(
    AppOutgoingEventPayloadSingleQuery query,
    CancellationToken cancellationToken)
  {
    using var httpClient = _httpClientFactory.CreateClient(AppSettings.HttpClientName);

    var httpResponseTask = httpClient.GetAsync(query.ToHttpRequestUrl(), cancellationToken);

    using var httpResponse = await httpResponseTask.ConfigureAwait(false);

    var resultTask = httpResponse.ToResultFromJsonAsync<AppOutgoingEventPayloadSingleDTO>(cancellationToken);

    var result = await resultTask.ConfigureAwait(false);

    return result;
  }
}
