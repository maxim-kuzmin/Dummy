namespace Makc.Dummy.Shared.Apps.WebApp.App.Middlewares;

/// <summary>
/// Промежуточный обработчик запроса для инициализации сессии приложения.
/// </summary>
/// <param name="_next">Следующий обработчик запроса.</param>
public class AppSessionMiddleware(RequestDelegate _next)
{
  /// <summary>
  /// Выполнить асинхронно.
  /// </summary>
  /// <param name="httpContext">HTTP-контекст.</param>
  /// <param name="appSession">Сессия приложения.</param>
  /// <param name="appConfigOptionsAuthenticationSectionSnapshot">
  /// Снимок раздела аутентификации в параметрах конфигурации приложения.
  /// </param>
  /// <returns>Задача.</returns>
  public async Task InvokeAsync(
    HttpContext httpContext,
    AppSession appSession,
    IOptionsSnapshot<AppConfigOptionsAuthenticationSection> appConfigOptionsAuthenticationSectionSnapshot)
  {
    var appConfigOptionsAuthenticationSection = appConfigOptionsAuthenticationSectionSnapshot.Value;

    string? accessToken = await httpContext.GetTokenAsync("access_token");

    var user = httpContext.User;

    if (appConfigOptionsAuthenticationSection.Type == AppConfigOptionsAuthenticationEnum.Keycloak)
    {
      accessToken = appConfigOptionsAuthenticationSection.CreateAccessToken(
        user.Identity?.Name,
        user.FindAll(ClaimTypes.Role).Select(x => x.Value));
    }

    appSession.AccessToken = accessToken;
    appSession.User = user;

    await _next(httpContext);
  }
}
