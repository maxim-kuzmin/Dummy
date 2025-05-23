namespace Makc.Dummy.Integration.MicroserviceWriter.Domain.UseCases.Auth.DTOs;

/// <summary>
/// Объект передачи данных входа для аутентификации.
/// </summary>
public record AuthLoginDTO
{
  /// <summary>
  /// Имя пользователя.
  /// </summary>
  public string UserName { get; set; } = string.Empty;

  /// <summary>
  /// Токен доступа.
  /// </summary>
  public string AccessToken { get; set; } = string.Empty;
}
