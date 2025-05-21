namespace Makc.Dummy.Integration.MicroserviceWriter.Infrastructure.HttpClient.AppOutgoingEventPayload.Services;

/// <summary>
/// Сервис команд полезной нагрузки исходящего события приложения.
/// </summary>
/// <param name="_httpClientFactory">Фабрика клиентов HTTP.</param>
public class AppOutgoingEventPayloadCommandService(
  IHttpClientFactory _httpClientFactory) : IAppOutgoingEventPayloadCommandService
{
  /// <inheritdoc/>
  public async Task<Result> Delete(
    AppOutgoingEventPayloadDeleteCommand command,
    CancellationToken cancellationToken)
  {
    using var httpClient = _httpClientFactory.CreateClient(AppSettings.HttpClientName);

    var httpResponseTask = httpClient.DeleteAsync(command.ToHttpRequestUrl(), cancellationToken);

    using var httpResponse = await httpResponseTask.ConfigureAwait(false);

    return httpResponse.ToResult();
  }

  public async Task<Result<AppOutgoingEventPayloadSingleDTO>> Save(
    AppOutgoingEventPayloadSaveCommand command,
    CancellationToken cancellationToken)
  {
    using var httpClient = _httpClientFactory.CreateClient(AppSettings.HttpClientName);

    using var httpRequestContent = command.Data.ToHttpRequestContent();

    string url = command.ToHttpRequestUrl();

    var httpResponseTask = command.IsUpdate
      ? httpClient.PutAsync(url, httpRequestContent, cancellationToken)
      : httpClient.PostAsync(url, httpRequestContent, cancellationToken);

    using var httpResponse = await httpResponseTask.ConfigureAwait(false);

    var resultTask = httpResponse.ToResultFromJsonAsync<AppOutgoingEventPayloadSingleDTO>(cancellationToken);

    var result = await resultTask.ConfigureAwait(false);

    return result;
  }
}
