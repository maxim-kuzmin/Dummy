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
    _logger.LogDebug("MAKC:AppOutboxCleanerService:ExecuteAsync start");

    bool isStarted = false;

    while (!stoppingToken.IsCancellationRequested)
    {
      using IServiceScope scope = _serviceScopeFactory.CreateScope();

      var appConfigOptionsSnapshot = scope.ServiceProvider.GetRequiredService<IOptionsSnapshot<AppConfigOptions>>();

      var options = Guard.Against.Null(appConfigOptionsSnapshot.Value.Domain?.AppOutbox?.Cleaner);

      int publishedEventsLifetimeInMinutes = Guard.Against.Negative(options.PublishedEventsLifetimeInMinutes);
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
        _logger.LogDebug("MAKC:AppOutboxCleanerService:ExecuteAsync:Load start");

        AppOutboxClearCommand command = new(PublishedEventsLifetimeInMinutes: publishedEventsLifetimeInMinutes);

        _logger.LogDebug("MAKC:AppOutboxCleanerService:ExecuteAsync:Load:Command: {command}", command);

        AppOutboxClearActionRequest request = new(command);

        await mediator.Send(request, stoppingToken).ConfigureAwait(false);

        _logger.LogDebug("MAKC:AppOutboxCleanerService:ExecuteAsync:Load end");
      }
      catch (OperationCanceledException)
      {
        _logger.LogDebug("MAKC:AppOutboxCleanerService:ExecuteAsync canceled");
      }
      catch (Exception ex)
      {
        _logger.LogError(ex, "MAKC:AppOutboxCleanerService:ExecuteAsync failed");
      }

      if (timeoutInMillisecondsToRepeat > 0)
      {
        await Task.Delay(timeoutInMillisecondsToRepeat, stoppingToken).ConfigureAwait(false);
      }
    }

    _logger.LogDebug("MAKC:AppOutboxCleanerService:ExecuteAsync end");
  }
}
