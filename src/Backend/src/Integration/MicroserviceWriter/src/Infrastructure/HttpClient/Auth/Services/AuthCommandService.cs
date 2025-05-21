namespace Makc.Dummy.Integration.MicroserviceWriter.Infrastructure.HttpClient.Auth.Services;

/// <summary>
/// Сервис команд аутентификации.
/// </summary>
/// <param name="_httpClientFactory">Фабрика клиентов HTTP.</param>
public class AuthCommandService(IHttpClientFactory _httpClientFactory) : IAuthCommandService
{
  /// <inheritdoc/>
  public async Task<Result<AuthLoginDTO>> Login(
    AuthLoginCommand command,
    CancellationToken cancellationToken)
  {
    using var httpClient = _httpClientFactory.CreateClient(AppSettings.HttpClientName);

    using var httpRequestContent = command.ToHttpRequestContent();

    var httpResponseTask = httpClient.PostAsync(
      AuthSettings.LoginActionUrl,
      httpRequestContent,
      cancellationToken);

    using var httpResponse = await httpResponseTask.ConfigureAwait(false);

    var resultTask = httpResponse.ToResultFromJsonAsync<AuthLoginDTO>(cancellationToken);

    var result = await resultTask.ConfigureAwait(false);

    return result;
  }
}
