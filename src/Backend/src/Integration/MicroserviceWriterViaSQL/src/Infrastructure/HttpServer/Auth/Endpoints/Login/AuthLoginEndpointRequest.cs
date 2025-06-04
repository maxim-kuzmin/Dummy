namespace Makc.Dummy.Integration.MicroserviceWriterViaSQL.Infrastructure.HttpServer.Auth.Endpoints.Login;

/// <summary>
/// Запрос конечной точки входа для аутентификации.
/// </summary>
/// <param name="UserName">Имя пользователя.</param>
/// <param name="Password">Пароль.</param>
public record AuthLoginEndpointRequest(
  string UserName,
  string Password);
