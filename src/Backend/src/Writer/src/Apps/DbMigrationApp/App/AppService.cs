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
    _logger.LogDebug("MAKC:AppService:ExecuteAsync:Start");

    while (!stoppingToken.IsCancellationRequested)
    {
      using IServiceScope scope = _serviceScopeFactory.CreateScope();

      var appConfigOptionsSnapshot = scope.ServiceProvider.GetRequiredService<IOptionsSnapshot<AppConfigOptions>>();

      var appConfigOptions = appConfigOptionsSnapshot.Value;

      bool shouldDbBePopulatedWithTestData = appConfigOptions.ShouldDbBePopulatedWithTestData;

      int timeoutToRetry = appConfigOptions.TimeoutInMillisecondsToRetry;

      _logger.LogDebug("MAKC:AppService:ExecuteAsync:ShouldDbBePopulatedWithTestData={shouldDbBePopulatedWithTestData}, TimeoutInMillisecondsToRetry={timeoutToRetry}", shouldDbBePopulatedWithTestData, timeoutToRetry);      

      var appDbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();

      try
      {
        await appDbContext.Database.MigrateAsync(stoppingToken).ConfigureAwait(false);

        _logger.LogDebug("MAKC:AppService:ExecuteAsync:Exception:Database migrated");

        await AppData.Initialize(appDbContext, shouldDbBePopulatedWithTestData, stoppingToken).ConfigureAwait(false);

        _logger.LogDebug("MAKC:AppService:ExecuteAsync:Exception:App data initialized");

        break;
      }
      catch (Exception ex)
      {
        _logger.LogError(ex, "MAKC:AppService:ExecuteAsync:Exception");
      }

      await Task.Delay(timeoutToRetry, stoppingToken).ConfigureAwait(false);
    }

    _hostApplicationLifetime.StopApplication();

    _logger.LogDebug("MAKC:AppService:ExecuteAsync:End");
  }
}
