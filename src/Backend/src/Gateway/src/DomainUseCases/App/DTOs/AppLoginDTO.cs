namespace Makc.Dummy.Gateway.DomainUseCases.App.DTOs;

/// <summary>
/// Объект передачи данных входа в приложение.
/// </summary>
/// <param name="UserName">Имя пользователя.</param>
/// <param name="AccessToken">Токен доступа.</param>
public record AppLoginDTO(
  string UserName,
  string AccessToken);
