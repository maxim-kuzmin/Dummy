namespace Makc.Dummy.Integration.MicroserviceWriterViaSQL.Infrastructure.HttpServer.Auth.Endpoints;

/// <summary>
/// Расширения конечных точек фиктивного предмета.
/// </summary>
public static class AuthEndpointsExtensions
{
  /// <summary>
  /// Преобразовать к запросу действия по входу для аутентификации.
  /// </summary>
  /// <param name="request">Запрос.</param>
  /// <returns>Запрос действия.</returns>
  public static AuthLoginActionRequest ToAuthLoginActionRequest(this AuthLoginEndpointRequest request)
  {
    AuthLoginCommand command = new(UserName: request.UserName, Password: request.Password);

    return new(command);
  }
}
