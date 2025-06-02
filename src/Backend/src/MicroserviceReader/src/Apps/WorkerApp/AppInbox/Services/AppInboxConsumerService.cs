namespace Makc.Dummy.MicroserviceReader.Apps.WorkerApp.AppInbox.Services;

/// <summary>
/// Сервис потребителя входящих сообщений приложения.
/// </summary>
/// <param name="_eventName">Имя события.</param>
/// <param name="_appMessageBroker">Брокер сообщений приложения.</param>
/// <param name="_appMessageConsumer">Потребитель сообщений приложения.</param>
/// <param name="_logger">Логгер.</param>
/// <param name="_serviceScopeFactory">Фабрика области видимости сервисов.</param>
public class AppInboxConsumerService(
  AppEventNameEnum _eventName,
  IAppMessageBroker _appMessageBroker,
  IAppMessageConsumer _appMessageConsumer,
  ILogger<AppInboxConsumerService> _logger,
  IServiceScopeFactory _serviceScopeFactory) : BackgroundService
{
  /// <inheritdoc/>
  protected override async Task ExecuteAsync(CancellationToken stoppingToken)
  {
    await _appMessageBroker.Connect(stoppingToken).ConfigureAwait(false);

    if (stoppingToken.IsCancellationRequested)
    {
      return;
    }

    MessageReceiving receiving = new(_eventName.ToString(), OnMessageReceived);

    await _appMessageConsumer.Subscribe(receiving, stoppingToken).ConfigureAwait(false);

    await Task.Delay(Timeout.Infinite, stoppingToken).ConfigureAwait(false);
  }

  private async Task OnMessageReceived(string sender, string message, CancellationToken cancellationToken)
  {
    if (cancellationToken.IsCancellationRequested)
    {
      return;
    }

    _logger.LogDebug("MAKC:AppInboxConsumerService:OnMessageReceived start");

    using var scope = _serviceScopeFactory.CreateScope();

    var mediator = scope.ServiceProvider.GetRequiredService<IMediator>();

    _logger.LogDebug("MAKC:AppInboxConsumerService:OnMessageReceived:Consume start");

    AppInboxConsumeCommand command = new(Sender: sender, Message: message);

    _logger.LogDebug("MAKC:AppInboxConsumerService:OnMessageReceived:Consume:Command: {command}", command);

    AppInboxConsumeActionRequest request = new(command);    

    await mediator.Send(request, cancellationToken).ConfigureAwait(false);

    _logger.LogDebug("MAKC:AppInboxConsumerService:OnMessageReceived:Consume end");

    _logger.LogDebug("MAKC:AppInboxConsumerService:OnMessageReceived end");
  }
}
