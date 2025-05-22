namespace Makc.Dummy.Integration.MicroserviceReader.Infrastructure.HttpClient.AppIncomingEvent.Services;

/// <summary>
/// Сервис команд входящего события приложения.
/// </summary>
/// <param name="_httpClientFactory">Фабрика клиентов HTTP.</param>
public class AppIncomingEventCommandService(
  IHttpClientFactory _httpClientFactory) : IAppIncomingEventCommandService
{
  /// <inheritdoc/>
  public async Task<Result> Delete(
    AppIncomingEventDeleteCommand command,
    CancellationToken cancellationToken)
  {
    using var httpClient = _httpClientFactory.CreateClient(AppSettings.HttpClientName);

    var httpResponseTask = httpClient.DeleteAsync(command.ToHttpRequestUrl(), cancellationToken);

    using var httpResponse = await httpResponseTask.ConfigureAwait(false);

    return httpResponse.ToResult();
  }

  public async Task<Result<AppIncomingEventSingleDTO>> Save(
    AppIncomingEventSaveCommand command,
    CancellationToken cancellationToken)
  {
    using var httpClient = _httpClientFactory.CreateClient(AppSettings.HttpClientName);

    using var httpRequestContent = command.Data.ToHttpRequestContent();

    string url = command.ToHttpRequestUrl();

    var httpResponseTask = command.IsUpdate
      ? httpClient.PutAsync(url, httpRequestContent, cancellationToken)
      : httpClient.PostAsync(url, httpRequestContent, cancellationToken);

    using var httpResponse = await httpResponseTask.ConfigureAwait(false);

    var resultTask = httpResponse.ToResultFromJsonAsync<AppIncomingEventSingleDTO>(cancellationToken);

    var result = await resultTask.ConfigureAwait(false);

    return result;
  }
}
