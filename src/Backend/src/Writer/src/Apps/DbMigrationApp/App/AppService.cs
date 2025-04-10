namespace Makc.Dummy.Writer.Apps.DbMigrationApp.App;

/// <summary>
/// Сервис приложения.
/// </summary>
/// <param name="_hostApplicationLifetime">Жизненный цикл приложения.</param>
/// <param name="_logger">Логгер.</param>
/// <param name="_serviceScopeFactory">Фабрика области видимости сервисов.</param>
public class AppService(
  IHostApplicationLifetime _hostApplicationLifetime,
  ILogger<AppService> _logger,
  IServiceScopeFactory _serviceScopeFactory) : BackgroundService
{
  /// <inheritdoc/>
  protected override async Task ExecuteAsync(CancellationToken stoppingToken)
  {
    while (!stoppingToken.IsCancellationRequested)
    {
      using IServiceScope scope = _serviceScopeFactory.CreateScope();

      var appConfigOptionsSnapshot = scope.ServiceProvider.GetRequiredService<IOptionsSnapshot<AppConfigOptions>>();

      var db = appConfigOptionsSnapshot.Value.Db;

      _logger.LogInformation("Db: {db}", db);

      if (_logger.IsEnabled(LogLevel.Information))
      {
        _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
      }

      await Task.Delay(0, stoppingToken);//await Task.Delay(Timeout.Infinite, stoppingToken);

      _hostApplicationLifetime.StopApplication();
    }
  }
}
