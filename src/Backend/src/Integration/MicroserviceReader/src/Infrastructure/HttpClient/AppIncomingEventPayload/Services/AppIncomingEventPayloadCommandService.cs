namespace Makc.Dummy.Integration.MicroserviceReader.Infrastructure.HttpClient.AppIncomingEventPayload.Services;

/// <summary>
/// Сервис команд полезной нагрузки входящего события приложения.
/// </summary>
/// <param name="_httpClientFactory">Фабрика клиентов HTTP.</param>
public class AppIncomingEventPayloadCommandService(
  IHttpClientFactory _httpClientFactory) : IAppIncomingEventPayloadCommandService
{
  /// <inheritdoc/>
  public async Task<Result> Delete(
    AppIncomingEventPayloadDeleteCommand command,
    CancellationToken cancellationToken)
  {
    using var httpClient = _httpClientFactory.CreateClient(AppSettings.HttpClientName);

    var httpResponseTask = httpClient.DeleteAsync(command.ToHttpRequestUrl(), cancellationToken);

    using var httpResponse = await httpResponseTask.ConfigureAwait(false);

    return httpResponse.ToResult();
  }

  public async Task<Result<AppIncomingEventPayloadSingleDTO>> Save(
    AppIncomingEventPayloadSaveCommand command,
    CancellationToken cancellationToken)
  {
    using var httpClient = _httpClientFactory.CreateClient(AppSettings.HttpClientName);

    using var httpRequestContent = command.Data.ToHttpRequestContent();

    string url = command.ToHttpRequestUrl();

    var httpResponseTask = command.IsUpdate
      ? httpClient.PutAsync(url, httpRequestContent, cancellationToken)
      : httpClient.PostAsync(url, httpRequestContent, cancellationToken);

    using var httpResponse = await httpResponseTask.ConfigureAwait(false);

    var resultTask = httpResponse.ToResultFromJsonAsync<AppIncomingEventPayloadSingleDTO>(cancellationToken);

    var result = await resultTask.ConfigureAwait(false);

    return result;
  }
}
