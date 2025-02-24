namespace Makc.Dummy.Writer.Infrastructure.RabbitMQ.App.Message;

/// <summary>
/// Поставщик сообщений приложения.
/// </summary>
/// <param name="options">Параметры.</param>
/// <param name="_logger">Логгер.</param>
public class AppMessageProducer(
  AppConfigOptionsRabbitMQSection options,
  ILogger<AppMessageProducer> _logger) : IAppMessageProducer
{
  private readonly ConnectionFactory _connectionFactory = new()
  {
    HostName = options.HostName,
    Password = options.Password,
    Port = options.Port,
    UserName = options.UserName
  };

  private readonly Channel<AppMessageSource> _sources = Channel.CreateUnbounded<AppMessageSource>(new()
  {
    SingleWriter = false,
    SingleReader = false,
    AllowSynchronousContinuations = true
  });

  /// <inheritdoc/>
  public ValueTask Publish(AppMessageSource source, CancellationToken cancellationToken)
  {
    return _sources.Writer.WriteAsync(source, cancellationToken);
  }

  /// <inheritdoc/>
  public async Task Start(CancellationToken cancellationToken)
  {
    while (!cancellationToken.IsCancellationRequested)
    {
      const int timeoutToRetry = 3000;      

      try
      {
        using var connection = await _connectionFactory.CreateConnectionAsync(cancellationToken);

        _logger.LogInformation("MAKC:Connected");

        var onShutdown = new TaskCompletionSource();

        connection.ConnectionShutdownAsync += (e, a) =>
        {
          _logger.LogInformation("MAKC:Shutdown");

          onShutdown.SetResult();

          return Task.CompletedTask;
        };

        using var channel = await connection.CreateChannelAsync(null, cancellationToken);

        await foreach (var source in _sources.Reader.ReadAllAsync(cancellationToken).ConfigureAwait(false))
        {
          var taskToPublish = Publish(channel, source.Message, cancellationToken);

          var taskToComplete = await Task.WhenAny(taskToPublish, onShutdown.Task);

          if (taskToComplete == onShutdown.Task)
          {
            source.OnCompleted.SetCanceled(cancellationToken);

            break;
          }
          else
          {
            source.OnCompleted.SetResult();
          }
        }
      }
      catch (TaskCanceledException ex)
      {
        _logger.LogError(ex, "MAKC: Canceled");

        break;
      }
      catch (Exception ex)
      {
        _logger.LogError(ex, "MAKC: Unknown");
      }

      await Task.Delay(timeoutToRetry, cancellationToken);
    }
  }

  private async Task Publish(IChannel channel, string message, CancellationToken cancellationToken)
  {
    const string exchange = "DummyItemChanged";

    await channel.ExchangeDeclareAsync(
      exchange: exchange,
      type: ExchangeType.Fanout,
      cancellationToken: cancellationToken);

    var body = Encoding.UTF8.GetBytes(message);

    await channel.BasicPublishAsync(
      exchange: exchange,
      routingKey: string.Empty,
      body: body,
      cancellationToken: cancellationToken);

    _logger.LogInformation("MAKC:Published: {message}", message);
  }
}

public record AppMessageSource(TaskCompletionSource OnCompleted, string Message);
