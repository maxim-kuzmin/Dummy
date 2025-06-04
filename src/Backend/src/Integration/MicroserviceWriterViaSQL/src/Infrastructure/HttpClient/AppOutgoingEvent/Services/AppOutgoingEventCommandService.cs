namespace Makc.Dummy.Integration.MicroserviceWriterViaSQL.Infrastructure.HttpClient.AppOutgoingEvent.Services;

/// <summary>
/// Сервис команд исходящего события приложения.
/// </summary>
/// <param name="_httpClientFactory">Фабрика клиентов HTTP.</param>
public class AppOutgoingEventCommandService(
  IHttpClientFactory _httpClientFactory) : IAppOutgoingEventCommandService
{
  /// <inheritdoc/>
  public async Task<Result> Delete(
    AppOutgoingEventDeleteCommand command,
    CancellationToken cancellationToken)
  {
    using var httpClient = _httpClientFactory.CreateClient(AppSettings.HttpClientName);

    var httpResponseTask = httpClient.DeleteAsync(command.ToHttpRequestUrl(), cancellationToken);

    using var httpResponse = await httpResponseTask.ConfigureAwait(false);

    return httpResponse.ToResult();
  }

  public async Task<Result<AppOutgoingEventSingleDTO>> Save(
    AppOutgoingEventSaveCommand command,
    CancellationToken cancellationToken)
  {
    using var httpClient = _httpClientFactory.CreateClient(AppSettings.HttpClientName);

    using var httpRequestContent = command.Data.ToHttpRequestContent();

    string url = command.ToHttpRequestUrl();

    var httpResponseTask = command.IsUpdate
      ? httpClient.PutAsync(url, httpRequestContent, cancellationToken)
      : httpClient.PostAsync(url, httpRequestContent, cancellationToken);

    using var httpResponse = await httpResponseTask.ConfigureAwait(false);

    var resultTask = httpResponse.ToResultFromJsonAsync<AppOutgoingEventSingleDTO>(cancellationToken);

    var result = await resultTask.ConfigureAwait(false);

    return result;
  }
}
