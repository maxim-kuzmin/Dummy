namespace Makc.Dummy.MicroserviceReader.Apps.WorkerApp.AppInbox.Services;

/// <summary>
/// Сервис обработчика входящих сообщений приложения.
/// </summary>
/// <param name="_eventName">Имя события.</param>
/// <param name="_logger">Логгер.</param>
/// <param name="_serviceScopeFactory">Фабрика области видимости сервисов.</param>
public class AppInboxProcessorService(
  AppEventNameEnum _eventName,
  ILogger<AppInboxProcessorService> _logger,
  IServiceScopeFactory _serviceScopeFactory) : BackgroundService
{
  /// <inheritdoc/>
  protected override async Task ExecuteAsync(CancellationToken stoppingToken)
  {
    _logger.LogDebug("MAKC:AppInboxProcessorService:ExecuteAsync start");

    while (!stoppingToken.IsCancellationRequested)
    {
      using IServiceScope scope = _serviceScopeFactory.CreateScope();

      var appConfigOptionsSnapshot = scope.ServiceProvider.GetRequiredService<IOptionsSnapshot<AppConfigOptions>>();

      var options = Guard.Against.Null(appConfigOptionsSnapshot.Value.Domain?.AppInbox?.Processor);

      int eventMaxCountToProcess = Guard.Against.NegativeOrZero(options.EventMaxCountToProcess);
      int timeoutInMillisecondsToRepeat = Guard.Against.Negative(options.TimeoutInMillisecondsToRepeat);

      var mediator = scope.ServiceProvider.GetRequiredService<IMediator>();

      try
      {
        _logger.LogDebug("MAKC:AppInboxProcessorService:ExecuteAsync:Process start");

        AppInboxProcessCommand command = new(
          EventName: _eventName.ToString(),
          EventMaxCountToProcess: eventMaxCountToProcess);

        _logger.LogDebug("MAKC:AppInboxProcessorService:ExecuteAsync:Process:Command: {command}", command);

        AppInboxProcessActionRequest request = new(command);

        await mediator.Send(request, stoppingToken).ConfigureAwait(false);

        _logger.LogDebug("MAKC:AppInboxProcessorService:ExecuteAsync:Process end");
      }
      catch (OperationCanceledException)
      {
        _logger.LogDebug("MAKC:AppInboxProcessorService:ExecuteAsync canceled");
      }
      catch (Exception ex)
      {
        _logger.LogError(ex, "MAKC:AppInboxProcessorService:ExecuteAsync failed");
      }

      if (timeoutInMillisecondsToRepeat > 0)
      {
        await Task.Delay(timeoutInMillisecondsToRepeat, stoppingToken).ConfigureAwait(false);
      }
    }

    _logger.LogDebug("MAKC:AppInboxProcessorService:ExecuteAsync end");
  }
}
