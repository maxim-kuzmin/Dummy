namespace Makc.Dummy.Gateway.Infrastructure.HttpForReader.App.Services;

/// <summary>
/// Сервис команд приложения.
/// </summary>
/// <param name="_httpClientFactory">Фабрика клиентов HTTP.</param>
public class AppCommandService(IHttpClientFactory _httpClientFactory) : IAppCommandService
{
  /// <inheritdoc/>
  public async Task<Result<AppLoginActionDTO>> Login(
    AppLoginActionCommand request,
    CancellationToken cancellationToken)
  {
    using var httpClient = _httpClientFactory.CreateClient(AppSettings.WriterDummyItemClientName);

    using var httpRequestContent = request.ToHttpRequestContent();

    var httpResponseTask = httpClient.PostAsync(
      AppSettings.LoginActionUrl,
      httpRequestContent,
      cancellationToken);

    using var httpResponse = await httpResponseTask.ConfigureAwait(false);

    var resultTask = httpResponse.ToResultFromJsonAsync<AppLoginActionDTO>(cancellationToken);

    var result = await resultTask.ConfigureAwait(false);

    return result;
  }
}
