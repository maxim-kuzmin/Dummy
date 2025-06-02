namespace Makc.Dummy.MicroserviceReader.Apps.WorkerApp.AppInbox.Services;

/// <summary>
/// Сервис загрузчика входящих сообщений приложения.
/// </summary>
/// <param name="_eventName">Имя события.</param>
/// <param name="_logger">Логгер.</param>
/// <param name="_serviceScopeFactory">Фабрика области видимости сервисов.</param>
public class AppInboxLoaderService(
  AppEventNameEnum _eventName,
  ILogger<AppInboxLoaderService> _logger,
  IServiceScopeFactory _serviceScopeFactory) : BackgroundService
{
  /// <inheritdoc/>
  protected override async Task ExecuteAsync(CancellationToken stoppingToken)
  {
    _logger.LogDebug("MAKC:AppInboxLoaderService:ExecuteAsync start");

    bool isStarted = false;

    while (!stoppingToken.IsCancellationRequested)
    {
      using IServiceScope scope = _serviceScopeFactory.CreateScope();

      var appConfigOptionsSnapshot = scope.ServiceProvider.GetRequiredService<IOptionsSnapshot<AppConfigOptions>>();

      var options = Guard.Against.Null(appConfigOptionsSnapshot.Value.Domain?.AppInbox?.Loader);

      int eventMaxCountToLoad = Guard.Against.NegativeOrZero(options.EventMaxCountToLoad);
      int payloadPageSize = Guard.Against.NegativeOrZero(options.PayloadPageSize);
      int timeoutInMillisecondsToGetPayloads = Guard.Against.Negative(options.TimeoutInMillisecondsToGetPayloads);
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
        _logger.LogDebug("MAKC:AppInboxLoaderService:ExecuteAsync:Load start");

        AppInboxLoadCommand command = new(
          EventName: _eventName.ToString(),
          EventMaxCountToLoad: eventMaxCountToLoad,
          PayloadPageSize: payloadPageSize,
          TimeoutInMillisecondsToGetPayloads: timeoutInMillisecondsToGetPayloads);

        _logger.LogDebug("MAKC:AppInboxLoaderService:ExecuteAsync:Load:Command: {command}", command);

        AppInboxLoadActionRequest request = new(command);

        await mediator.Send(request, stoppingToken).ConfigureAwait(false);

        _logger.LogDebug("MAKC:AppInboxLoaderService:ExecuteAsync:Load end");
      }
      catch (OperationCanceledException)
      {
        _logger.LogDebug("MAKC:AppInboxLoaderService:ExecuteAsync canceled");
      }
      catch (Exception ex)
      {
        _logger.LogError(ex, "MAKC:AppInboxLoaderService:ExecuteAsync failed");
      }

      if (timeoutInMillisecondsToRepeat > 0)
      {
        await Task.Delay(timeoutInMillisecondsToRepeat, stoppingToken).ConfigureAwait(false);
      }
    }

    _logger.LogDebug("MAKC:AppInboxLoaderService:ExecuteAsync end");
  }
}
