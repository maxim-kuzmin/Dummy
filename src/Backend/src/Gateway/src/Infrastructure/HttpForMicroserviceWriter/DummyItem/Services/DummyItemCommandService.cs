namespace Makc.Dummy.Gateway.Infrastructure.HttpForMicroserviceWriter.DummyItem.Services;

/// <summary>
/// Сервис команд фиктивного предмета.
/// </summary>
/// <param name="_httpClientFactory">Фабрика клиентов HTTP.</param>
public class DummyItemCommandService(
  IHttpClientFactory _httpClientFactory) : IDummyItemCommandService
{
  /// <inheritdoc/>
  public async Task<Result<DummyItemSingleDTO>> Create(
    DummyItemCreateActionCommand command,
    CancellationToken cancellationToken)
  {
    using var httpClient = _httpClientFactory.CreateClient(AuthSettings.HttpClientName);

    using var httpRequestContent = command.ToHttpRequestContent();

    var httpResponseTask = httpClient.PostAsync(
      DummyItemSettings.Root,
      httpRequestContent,
      cancellationToken);

    using var httpResponse = await httpResponseTask.ConfigureAwait(false);

    var resultTask = httpResponse.ToResultFromJsonAsync<DummyItemSingleDTO>(cancellationToken);

    var result = await resultTask.ConfigureAwait(false);

    return result;
  }

  /// <inheritdoc/>
  public async Task<Result> Delete(
    DummyItemDeleteActionCommand command,
    CancellationToken cancellationToken)
  {
    using var httpClient = _httpClientFactory.CreateClient(AuthSettings.HttpClientName);

    var httpResponseTask = httpClient.DeleteAsync(command.ToHttpRequestUrl(), cancellationToken);

    using var httpResponse = await httpResponseTask.ConfigureAwait(false);

    return httpResponse.ToResult();
  }

  /// <inheritdoc/>
  public async Task<Result<DummyItemSingleDTO>> Update(
      DummyItemUpdateActionCommand command,
      CancellationToken cancellationToken)
  {
    using var httpClient = _httpClientFactory.CreateClient(AuthSettings.HttpClientName);

    using var httpRequestContent = command.ToHttpRequestContent();

    var httpResponseTask = httpClient.PutAsync(
      command.ToHttpRequestUrl(),
      httpRequestContent,
      cancellationToken);

    using var httpResponse = await httpResponseTask.ConfigureAwait(false);

    var resultTask = httpResponse.ToResultFromJsonAsync<DummyItemSingleDTO>(cancellationToken);

    var result = await resultTask.ConfigureAwait(false);

    return result;
  }
}
