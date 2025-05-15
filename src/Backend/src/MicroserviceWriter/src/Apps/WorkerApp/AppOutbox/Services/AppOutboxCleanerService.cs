namespace Makc.Dummy.MicroserviceWriter.Apps.WorkerApp.AppOutbox.Services;

/// <summary>
/// Сервис чистильщика исходящих сообщений приложения.
/// </summary>
/// <param name="_logger">Логгер.</param>
/// <param name="_serviceScopeFactory">Фабрика области видимости сервисов.</param>
public class AppOutboxCleanerService(
  ILogger<AppOutboxCleanerService> _logger,
  IServiceScopeFactory _serviceScopeFactory) : BackgroundService
{
  /// <inheritdoc/>
  protected override async Task ExecuteAsync(CancellationToken stoppingToken)
  {
    while (!stoppingToken.IsCancellationRequested)
    {
      using var scope = _serviceScopeFactory.CreateScope();

      var appConfigOptionsSnapshot = scope.ServiceProvider.GetRequiredService<IOptionsSnapshot<AppConfigOptions>>();

      var options = Guard.Against.Null(appConfigOptionsSnapshot.Value.Infrastructure?.PostgreSQL);

      _logger.LogInformation("Options: {options}", options);

      if (_logger.IsEnabled(LogLevel.Information))
      {
        _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
      }

      await Task.Delay(Timeout.Infinite, stoppingToken);
    }
  }
}
