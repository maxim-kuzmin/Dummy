namespace Makc.Dummy.Gateway.Infrastructure.HttpForMicroserviceWriter.DummyItem.Services;

/// <summary>
/// Сервис команд фиктивного предмета.
/// </summary>
/// <param name="_httpClientFactory">Фабрика клиентов HTTP.</param>
public class DummyItemCommandService(
  IHttpClientFactory _httpClientFactory) : IDummyItemCommandService
{
  /// <inheritdoc/>
  public async Task<Result> Delete(
    DummyItemDeleteCommand command,
    CancellationToken cancellationToken)
  {
    using var httpClient = _httpClientFactory.CreateClient(AuthSettings.HttpClientName);

    var httpResponseTask = httpClient.DeleteAsync(command.ToHttpRequestUrl(), cancellationToken);

    using var httpResponse = await httpResponseTask.ConfigureAwait(false);

    return httpResponse.ToResult();
  }

  public async Task<Result<DummyItemSingleDTO>> Save(
    DummyItemSaveCommand command,
    CancellationToken cancellationToken)
  {
    using var httpClient = _httpClientFactory.CreateClient(AuthSettings.HttpClientName);

    using var httpRequestContent = command.Data.ToHttpRequestContent();

    string url = command.ToHttpRequestUrl();

    var httpResponseTask = command.IsUpdate
      ? httpClient.PutAsync(url, httpRequestContent, cancellationToken)
      : httpClient.PostAsync(url, httpRequestContent, cancellationToken);

    using var httpResponse = await httpResponseTask.ConfigureAwait(false);

    var resultTask = httpResponse.ToResultFromJsonAsync<DummyItemSingleDTO>(cancellationToken);

    var result = await resultTask.ConfigureAwait(false);

    return result;
  }
}
