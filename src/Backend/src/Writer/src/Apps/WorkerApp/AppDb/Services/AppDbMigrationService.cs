namespace Makc.Dummy.Writer.Apps.WorkerApp.AppDb.Services;

/// <summary>
/// Сервис миграции базы данных приложения.
/// </summary>
/// <param name="_hostApplicationLifetime">Жизненный цикл приложения.</param>
/// <param name="_logger">Логгер.</param>
/// <param name="_serviceScopeFactory">Фабрика области видимости сервисов.</param>
public class AppDbMigrationService(
  IHostApplicationLifetime _hostApplicationLifetime,
  ILogger<AppDbMigrationService> _logger,
  IServiceScopeFactory _serviceScopeFactory) : BackgroundService
{
  /// <inheritdoc/>
  protected override async Task ExecuteAsync(CancellationToken stoppingToken)
  {
    _logger.LogDebug("MAKC:AppDbMigrationService:ExecuteAsync start");

    while (!stoppingToken.IsCancellationRequested)
    {
      using var scope = _serviceScopeFactory.CreateScope();

      var appConfigOptionsSnapshot = scope.ServiceProvider.GetRequiredService<IOptionsSnapshot<AppConfigOptions>>();

      var options = Guard.Against.Null(appConfigOptionsSnapshot.Value.Domain?.AppDb?.Migration);

      bool shouldDbBePopulatedWithTestData = options.ShouldDbBePopulatedWithTestData;

      int timeoutToRetry = options.TimeoutInMillisecondsToRetry;

      _logger.LogDebug("MAKC:AppDbMigrationService:ExecuteAsync:ShouldDbBePopulatedWithTestData={shouldDbBePopulatedWithTestData}, TimeoutInMillisecondsToRetry={timeoutToRetry}", shouldDbBePopulatedWithTestData, timeoutToRetry);

      var appDbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();

      while (!stoppingToken.IsCancellationRequested)
      {
        try
        {
          _logger.LogDebug("MAKC:AppDbMigrationService:ExecuteAsync:Migration start");

          await appDbContext.Database.MigrateAsync(stoppingToken).ConfigureAwait(false);

          _logger.LogDebug("MAKC:AppDbMigrationService:ExecuteAsync:Migration end");

          break;
        }
        catch (Exception ex)
        {
          _logger.LogError(ex, "MAKC:AppDbMigrationService:ExecuteAsync failed");
        }

        await Task.Delay(timeoutToRetry, stoppingToken).ConfigureAwait(false);
      }

      if (shouldDbBePopulatedWithTestData)
      {
        _logger.LogDebug("MAKC:AppDbMigrationService:ExecuteAsync:PopulationWithTestData start");

        var appDbSQLExecutionContext = scope.ServiceProvider.GetRequiredService<IAppDbSQLExecutionContext>();
        var mediator = scope.ServiceProvider.GetRequiredService<IMediator>();

        var task = appDbContext.PopulateWithTestData(appDbSQLExecutionContext, mediator, stoppingToken);

        await task.ConfigureAwait(false);

        _logger.LogDebug("MAKC:AppDbMigrationService:ExecuteAsync:PopulationWithTestData end");
      }

      break;
    }

    _hostApplicationLifetime.StopApplication();

    _logger.LogDebug("MAKC:AppDbMigrationService:ExecuteAsync end");
  }
}
