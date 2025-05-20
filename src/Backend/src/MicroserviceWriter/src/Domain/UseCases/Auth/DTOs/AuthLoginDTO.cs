namespace Makc.Dummy.MicroserviceWriter.Domain.UseCases.Auth.DTOs;

/// <summary>
/// Объект передачи данных входа для аутентификации.
/// </summary>
/// <param name="UserName">Имя пользователя.</param>
/// <param name="AccessToken">Токен доступа.</param>
public record AuthLoginDTO(
  string UserName,
  string AccessToken);
