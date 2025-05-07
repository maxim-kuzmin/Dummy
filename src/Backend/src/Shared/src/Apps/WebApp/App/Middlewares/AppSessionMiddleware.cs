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
  /// <param name="optionsSnapshot">Снимок параметров.</param>
  /// <returns>Задача.</returns>
  public async Task InvokeAsync(
    HttpContext httpContext,
    AppSession appSession,
    IOptionsSnapshot<AppConfigOptionsDomainAuthSection> optionsSnapshot)
  {
    var options = optionsSnapshot.Value;

    string? accessToken = await httpContext.GetTokenAsync("access_token");

    var user = httpContext.User;

    if (options.Type == AppConfigOptionsAuthenticationEnum.Keycloak)
    {
      accessToken = options.CreateAccessToken(
        user.Identity?.Name,
        user.FindAll(ClaimTypes.Role).Select(x => x.Value));
    }

    appSession.AccessToken = accessToken;
    appSession.User = user;

    await _next(httpContext);
  }
}
