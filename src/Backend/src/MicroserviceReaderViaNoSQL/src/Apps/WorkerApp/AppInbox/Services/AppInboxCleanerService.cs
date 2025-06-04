namespace Makc.Dummy.MicroserviceReaderViaNoSQL.Apps.WorkerApp.AppInbox.Services;

/// <summary>
/// Сервис чистильщика входящих сообщений приложения.
/// </summary>
/// <param name="_logger">Логгер.</param>
/// <param name="_serviceScopeFactory">Фабрика области видимости сервисов.</param>
public class AppInboxCleanerService(
  ILogger<AppInboxCleanerService> _logger,
  IServiceScopeFactory _serviceScopeFactory) : BackgroundService
{
  /// <inheritdoc/>
  protected override async Task ExecuteAsync(CancellationToken stoppingToken)
  {
    _logger.LogDebug("MAKC:AppInboxCleanerService:ExecuteAsync start");

    bool isStarted = false;

    while (!stoppingToken.IsCancellationRequested)
    {
      using IServiceScope scope = _serviceScopeFactory.CreateScope();

      var appConfigOptionsSnapshot = scope.ServiceProvider.GetRequiredService<IOptionsSnapshot<AppConfigOptions>>();

      var options = Guard.Against.Null(appConfigOptionsSnapshot.Value.Domain?.AppInbox?.Cleaner);

      int eventMaxCountToClear = Guard.Against.Negative(options.EventMaxCountToClear);
      int processedEventsLifetimeInMinutes = Guard.Against.Negative(options.ProcessedEventsLifetimeInMinutes);
      int timeoutInMillisecondsToGetEvents = Guard.Against.Negative(options.TimeoutInMillisecondsToGetEvents);
      int timeoutInMillisecondsToRepeat = Guard.Against.Negative(options.TimeoutInMillisecondsToRepeat);
      int timeoutInMillisecondsToStart = Guard.Against.Negative(options.TimeoutInMillisecondsToStart);

      if (!isStarted && timeoutInMillisecondsToStart > 0)
      {
        await Task.Delay(timeoutInMillisecondsToStart, stoppingToken).ConfigureAwait(false);

        isStarted = true;
      }

      var mediator = scope.ServiceProvider.GetRequiredService<IMediator>();

      try
      {
        _logger.LogDebug("MAKC:AppInboxCleanerService:ExecuteAsync:Load start");

        AppInboxClearCommand command = new(
          EventMaxCountToClear: eventMaxCountToClear,
          ProcessedEventsLifetimeInMinutes: processedEventsLifetimeInMinutes,
          TimeoutInMillisecondsToGetEvents: timeoutInMillisecondsToGetEvents);

        _logger.LogDebug("MAKC:AppInboxCleanerService:ExecuteAsync:Load:Command: {command}", command);

        AppInboxClearActionRequest request = new(command);

        await mediator.Send(request, stoppingToken).ConfigureAwait(false);

        _logger.LogDebug("MAKC:AppInboxCleanerService:ExecuteAsync:Load end");
      }
      catch (OperationCanceledException)
      {
        _logger.LogDebug("MAKC:AppInboxCleanerService:ExecuteAsync canceled");
      }
      catch (Exception ex)
      {
        _logger.LogError(ex, "MAKC:AppInboxCleanerService:ExecuteAsync failed");
      }

      if (timeoutInMillisecondsToRepeat > 0)
      {
        await Task.Delay(timeoutInMillisecondsToRepeat, stoppingToken).ConfigureAwait(false);
      }
    }

    _logger.LogDebug("MAKC:AppInboxCleanerService:ExecuteAsync end");
  }
}
