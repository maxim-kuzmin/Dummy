namespace Makc.Dummy.Reader.Apps.WorkerApp.AppInbox.Services;

/// <summary>
/// Сервис потребителя входящих сообщений приложения.
/// </summary>
/// <param name="_appMessageBroker">Брокер сообщений приложения.</param>
/// <param name="_appMessageConsumer">Потребитель сообщений приложения.</param>
/// <param name="_serviceScopeFactory">Фабрика области видимости сервисов.</param>
public class AppInboxConsumerService(
  IAppMessageBroker _appMessageBroker,
  IAppMessageConsumer _appMessageConsumer,
  IServiceScopeFactory _serviceScopeFactory) : BackgroundService
{
  private IMediator? _mediator;

  /// <inheritdoc/>
  protected override async Task ExecuteAsync(CancellationToken stoppingToken)
  {
    var connectionTask = _appMessageBroker.Connect(stoppingToken);

    await connectionTask.ConfigureAwait(false);

    if (stoppingToken.IsCancellationRequested)
    {
      return;
    }

    using var scope = _serviceScopeFactory.CreateScope();

    _mediator = scope.ServiceProvider.GetRequiredService<IMediator>();

    MessageReceiving receiving = new(AppEventNameEnum.DummyItemChanged.ToString(), OnMessageReceived);

    var subscribtionTask = _appMessageConsumer.Subscribe(receiving, stoppingToken);

    await subscribtionTask.ConfigureAwait(false);

    await Task.Delay(Timeout.Infinite, stoppingToken).ConfigureAwait(false);
  }

  private async Task OnMessageReceived(string sender, string message, CancellationToken cancellationToken)
  {
    Guard.Against.Null(_mediator);

    AppInboxConsumeActionCommand command = new(sender, message);

    await _mediator.Send(command, cancellationToken).ConfigureAwait(false);
  }
}
