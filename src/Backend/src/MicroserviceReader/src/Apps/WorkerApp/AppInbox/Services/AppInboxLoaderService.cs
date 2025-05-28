namespace Makc.Dummy.MicroserviceReader.Apps.WorkerApp.AppInbox.Services;

/// <summary>
/// Сервис загрузчика входящих сообщений приложения.
/// </summary>
/// <param name="_logger">Логгер.</param>
/// <param name="_serviceScopeFactory">Фабрика области видимости сервисов.</param>
public class AppInboxLoaderService(
  ILogger<AppInboxLoaderService> _logger,
  IServiceScopeFactory _serviceScopeFactory) : BackgroundService
{
  /// <inheritdoc/>
  protected override async Task ExecuteAsync(CancellationToken stoppingToken)
  {
    while (!stoppingToken.IsCancellationRequested)
    {
      using IServiceScope scope = _serviceScopeFactory.CreateScope();

      var appConfigOptionsSnapshot = scope.ServiceProvider.GetRequiredService<IOptionsSnapshot<AppConfigOptions>>();

      var options = Guard.Against.Null(appConfigOptionsSnapshot.Value.Infrastructure?.MongoDB);

      _logger.LogInformation("Options: {options}", options);

      if (_logger.IsEnabled(LogLevel.Information))
      {
        _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
      }

      await Task.Delay(Timeout.Infinite, stoppingToken);
    }
  }
}
