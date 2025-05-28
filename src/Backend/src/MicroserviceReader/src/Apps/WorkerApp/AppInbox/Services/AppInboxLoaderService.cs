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
    _logger.LogDebug("MAKC:AppInboxLoaderService:ExecuteAsync start");

    while (!stoppingToken.IsCancellationRequested)
    {
      using IServiceScope scope = _serviceScopeFactory.CreateScope();

      var appConfigOptionsSnapshot = scope.ServiceProvider.GetRequiredService<IOptionsSnapshot<AppConfigOptions>>();

      var options = Guard.Against.Null(appConfigOptionsSnapshot.Value.Domain?.AppInbox?.Loader);

      int maxCount = options.MaxCount;
      int timeoutToRepeat = options.TimeoutInMillisecondsToRepeat;

      var mediator = scope.ServiceProvider.GetRequiredService<IMediator>();

      try
      {
        _logger.LogDebug("MAKC:AppInboxLoaderService:ExecuteAsync:Load start");

        AppInboxLoadCommand command = new(
          EventName: AppEventNameEnum.DummyItemChanged.ToString(),
          MaxCount: maxCount);

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

      await Task.Delay(timeoutToRepeat, stoppingToken);
    }

    _logger.LogDebug("MAKC:AppInboxLoaderService:ExecuteAsync end");
  }
}
