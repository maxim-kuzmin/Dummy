namespace Makc.Dummy.Gateway.DomainUseCases.App.Actions.Login;

/// <summary>
/// Обработчик действия по входу в приложение.
/// </summary>
/// <param name="_appConfigOptionsAuthenticationSectionSnapshot">
/// Снимок раздела аутентификации в параметрах конфигурации приложения.
/// </param>
/// <param name="_appConfigOptionsKeycloakSectionSnapshot">
/// Снимок раздела поставщика OpenID Keycloak в параметрах конфигурации приложения.
/// </param>
/// <param name="_httpClientFactory">Фабрика клиентов HTTP.</param>
/// <param name="_service">Сервис.</param>
public class AppLoginActionHandler(
  IOptionsSnapshot<AppConfigOptionsAuthenticationSection> _appConfigOptionsAuthenticationSectionSnapshot,
  IOptionsSnapshot<AppConfigOptionsKeycloakSection> _appConfigOptionsKeycloakSectionSnapshot,
  IHttpClientFactory _httpClientFactory,
  IAppActionCommandService _service) :
  ICommandHandler<AppLoginActionCommand, Result<AppLoginActionDTO>>
{
  /// <inheritdoc/>
  public async Task<Result<AppLoginActionDTO>> Handle(AppLoginActionCommand request, CancellationToken cancellationToken)
  {
    Result<AppLoginActionDTO> result;

    var appConfigOptionsAuthenticationSection = _appConfigOptionsAuthenticationSectionSnapshot.Value;

    var appConfigOptionsKeycloakSection = _appConfigOptionsKeycloakSectionSnapshot.Value;

    if (appConfigOptionsAuthenticationSection.Type == AppConfigOptionsAuthenticationEnum.Keycloak)
    {
      using var httpClient = _httpClientFactory.CreateClient(AppSettings.KeycloakClientName);

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

      var resultTask = httpResponse.ToResultFromJsonAsync<AppLoginActionDTO, TokenResponse>(
        content => new AppLoginActionDTO(request.UserName, content.AccessToken ?? string.Empty),
        cancellationToken);

      result = await resultTask.ConfigureAwait(false);
    }
    else
    {
      result = await _service.Login(request, cancellationToken).ConfigureAwait(false);
    }

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
