namespace Makc.Dummy.Gateway.Domain.Model.App;

/// <summary>
/// Расширения приложения.
/// </summary>
public static class AppExtensions
{
  /// <summary>
  /// Добавить модель предметной области приложения.
  /// </summary>
  /// <param name="services">Сервисы.</param>
  /// <param name="logger">Логгер.</param>
  /// <returns>Сервисы.</returns>
  public static IServiceCollection AddAppDomainModel(this IServiceCollection services, ILogger logger)
  {
    logger.LogInformation("Added application domain model");

    return services;
  }
}
