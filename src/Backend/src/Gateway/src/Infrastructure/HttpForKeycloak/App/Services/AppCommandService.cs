namespace Makc.Dummy.Gateway.Infrastructure.HttpForKeycloak.App.Services;

/// <summary>
/// Сервис команд приложения.
/// </summary>
/// <param name="_appConfigOptionsKeycloakSectionSnapshot">
/// Снимок раздела поставщика OpenID Keycloak в параметрах конфигурации приложения.
/// </param>
/// <param name="_httpClientFactory">Фабрика клиентов HTTP.</param>
public class AppCommandService(
  IOptionsSnapshot<AppConfigOptionsKeycloakSection> _appConfigOptionsKeycloakSectionSnapshot,
  IHttpClientFactory _httpClientFactory) : IAuthCommandService
{
  /// <inheritdoc/>
  public async Task<Result<AuthLoginDTO>> Login(
    AuthLoginActionCommand request,
    CancellationToken cancellationToken)
  {
    var appConfigOptionsKeycloakSection = _appConfigOptionsKeycloakSectionSnapshot.Value;

    using var httpClient = _httpClientFactory.CreateClient(AppSettings.HttpClientName);

    Dictionary<string, string> httpRequestBody = new()
    {
      { "grant_type", "password" },
      { "client_id", appConfigOptionsKeycloakSection.ClientId },
      { "client_secret", appConfigOptionsKeycloakSection.ClientSecret },
      { "username", request.UserName },
      { "password", request.Password }
    };

    using var httpRequestContent = new FormUrlEncodedContent(httpRequestBody);

    var httpResponseTask = httpClient.PostAsync(
      $"realms/{appConfigOptionsKeycloakSection.Realm}/protocol/openid-connect/token",
      httpRequestContent,
      cancellationToken);

    using var httpResponse = await httpResponseTask.ConfigureAwait(false);

    var resultTask = httpResponse.ToResultFromJsonAsync<AuthLoginDTO, TokenResponse>(
      content => new AuthLoginDTO(request.UserName, content.AccessToken ?? string.Empty),
      cancellationToken);

    var result = await resultTask.ConfigureAwait(false);

    return result;
  }

  private class TokenResponse
  {
    [JsonPropertyName("access_token")]
    public string? AccessToken { get; set; }

    [JsonPropertyName("expires_in")]
    public int ExpiresIn { get; set; }

    [JsonPropertyName("refresh_token")]
    public string? RefreshToken { get; set; }
  }
}
