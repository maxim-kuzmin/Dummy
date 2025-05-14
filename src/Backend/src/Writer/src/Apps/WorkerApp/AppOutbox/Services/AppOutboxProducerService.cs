namespace Makc.Dummy.Writer.Apps.WorkerApp.AppOutbox.Services;

/// <summary>
/// Сервис поставщика исходящих сообщений приложения.
/// </summary>
/// <param name="_appMessageBroker">Брокер сообщений приложения.</param>
/// <param name="_logger">Логгер.</param>
/// <param name="_serviceScopeFactory">Фабрика области видимости сервисов.</param>
public class AppOutboxProducerService(
  IAppMessageBroker _appMessageBroker,
  ILogger<AppOutboxProducerService> _logger,
  IServiceScopeFactory _serviceScopeFactory) : BackgroundService
{
  /// <inheritdoc/>
  protected override async Task ExecuteAsync(CancellationToken stoppingToken)
  {
    _logger.LogDebug("MAKC:AppOutboxProducerService:ExecuteAsync start");

    _logger.LogDebug("MAKC:AppOutboxProducerService:ExecuteAsync:Connect start");

    await _appMessageBroker.Connect(stoppingToken).ConfigureAwait(false);

    _logger.LogDebug("MAKC:AppOutboxProducerService:ExecuteAsync:Connect end");

    while (!stoppingToken.IsCancellationRequested)
    {
      using var scope = _serviceScopeFactory.CreateScope();

      var appConfigOptionsSnapshot = scope.ServiceProvider.GetRequiredService<IOptionsSnapshot<AppConfigOptions>>();

      var options = Guard.Against.Null(appConfigOptionsSnapshot.Value.Domain?.AppOutbox?.Producer);

      int maxCount = options.MaxCount;
      int timeoutToRepeat = options.TimeoutInMillisecondsToRepeat;

      var mediator = scope.ServiceProvider.GetRequiredService<IMediator>();

      try
      {
        _logger.LogDebug("MAKC:AppOutboxProducerService:ExecuteAsync:Produce start");

        AppOutboxProduceActionCommand command = new(maxCount);

        _logger.LogDebug("MAKC:AppOutboxProducerService:ExecuteAsync:Produce:Command: {command}", command);

        await mediator.Send(command, stoppingToken).ConfigureAwait(false);

        _logger.LogDebug("MAKC:AppOutboxProducerService:ExecuteAsync:Produce end");
      }
      catch (OperationCanceledException)
      {
        _logger.LogDebug("MAKC:AppOutboxProducerService:ExecuteAsync canceled");
      }
      catch (Exception ex)
      {
        _logger.LogError(ex, "MAKC:AppOutboxProducerService:ExecuteAsync failed");
      }

      await Task.Delay(timeoutToRepeat, stoppingToken);
    }

    _logger.LogDebug("MAKC:AppOutboxProducerService:ExecuteAsync end");
  }  
}
