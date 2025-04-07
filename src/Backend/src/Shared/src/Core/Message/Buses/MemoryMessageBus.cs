namespace Makc.Dummy.Shared.Core.Message.Buses;

/// <summary>
/// Шина сообщений, хранящихся в памяти.
/// </summary>
/// <param name="_logger">Логгер.</param>
public class MemoryMessageBus(ILogger<MemoryMessageBus> _logger) : MessageBusBase(_logger)
{
  private readonly Dictionary<string, Channel<string>> _channelLookup = [];

  /// <inheritdoc/>
  public sealed override Task Connect(CancellationToken cancellationToken)
  {
    if (cancellationToken.IsCancellationRequested)
    {
      return Task.FromCanceled(cancellationToken);
    }

    if (!Init(AppConfigOptionsMessageDirectionEnum.Both))
    {
      return Task.CompletedTask;
    }

    TaskCompletionSource connectionCompletion = new();

    Task FuncToExecute(TaskCompletionSource shutdownCompletion, CancellationToken cancellationToken)
    {
      TaskCompletionSource consumingCompletion = new();

      if (ReceivingChannel != null)
      {
        var consumingTask = Task.Run(
          () => Consume(ReceivingChannel, consumingCompletion, shutdownCompletion, cancellationToken),
          cancellationToken);

        if (consumingTask.IsCanceled)
        {
          return consumingTask;
        }
      }
      else
      {
        consumingCompletion.SetResult();
      }

      TaskCompletionSource producingCompletion = new();

      if (SendingChannel != null)
      {
        var producingTask = Task.Run(
          () => Produce(SendingChannel, producingCompletion, shutdownCompletion, cancellationToken),
          cancellationToken);

        if (producingTask.IsCanceled)
        {
          return producingTask;
        }
      }
      else
      {
        producingCompletion.SetResult();
      }

      return Task.WhenAll(consumingCompletion.Task, producingCompletion.Task);
    }

    var connectionTask = Task.Run(
      () => Connect(connectionCompletion, FuncToExecute, cancellationToken),
      cancellationToken);

    if (connectionTask.IsCanceled)
    {
      return connectionTask;
    }

    return connectionCompletion.Task;
  }

  private async Task Connect(
    TaskCompletionSource connectionCompletion,
    Func<TaskCompletionSource, CancellationToken, Task> funcToExecute,
    CancellationToken cancellationToken)
  {
    try
    {
      TaskCompletionSource shutdownCompletion = new();

      await funcToExecute.Invoke(shutdownCompletion, cancellationToken).ConfigureAwait(false);

      connectionCompletion.SetResult();

      _logger.LogDebug("MAKC:Connected");

      await shutdownCompletion.Task.ConfigureAwait(false);

      _logger.LogDebug("MAKC:Shutdown");
    }
    catch (Exception ex)
    {
      _logger.LogError(ex, "MAKC:Unknown");
    }
  }

  private async Task Consume(
    Channel<MessageReceiving> receivingChannel,
    TaskCompletionSource consumingCompletion,
    TaskCompletionSource shutdownCompletion,
    CancellationToken cancellationToken)
  {
    if (!consumingCompletion.Task.IsCompleted)
    {
      consumingCompletion.SetResult();
    }

    await foreach (var receiving in receivingChannel.Reader.ReadAllAsync(cancellationToken).ConfigureAwait(false))
    {
      if (CheckShutdown(shutdownCompletion, cancellationToken))
      {
        break;
      }
      
      await Receive(receiving, shutdownCompletion, cancellationToken).ConfigureAwait(false);

      if (CheckShutdown(shutdownCompletion, cancellationToken))
      {
        break;
      }
    }
  }

  private Channel<string> GetMessageChannel(string key)
  {
    lock (_channelLookup)
    {
      if (!_channelLookup.TryGetValue(key, out var result))
      {
        result = Channel.CreateUnbounded<string>(new()
        {
          SingleWriter = false,
          SingleReader = false,
          AllowSynchronousContinuations = true
        });

        _channelLookup[key] = result;
      }

      return result;
    }
  }

  private async Task Produce(
    Channel<MessageSending> sendingChannel,
    TaskCompletionSource producingCompletion,
    TaskCompletionSource shutdownCompletion,
    CancellationToken cancellationToken)
  {
    if (!producingCompletion.Task.IsCompleted)
    {
      producingCompletion.SetResult();
    }

    await foreach (var sending in sendingChannel.Reader.ReadAllAsync(cancellationToken).ConfigureAwait(false))
    {
      if (CheckShutdown(shutdownCompletion, cancellationToken))
      {
        sending.Cancel(cancellationToken);

        break;
      }

      await Send(sending, cancellationToken).ConfigureAwait(false);

      if (CheckShutdown(shutdownCompletion, cancellationToken))
      {
        sending.Cancel(cancellationToken);

        break;
      }

      sending.Complete();
    }
  }

  private Task Receive(
    MessageReceiving receiving,
    TaskCompletionSource shutdownCompletion,
    CancellationToken cancellationToken)
  {
    TaskCompletionSource receivingCompletion = new();

    var receivingTask = Task.Run(
      () => Receive(receiving, receivingCompletion, shutdownCompletion, cancellationToken),
      cancellationToken);

    if (receivingTask.IsCanceled)
    {
      return receivingTask;
    }

    return receivingCompletion.Task;
  }

  private async Task Receive(
    MessageReceiving receiving,
    TaskCompletionSource receivingCompletion,
    TaskCompletionSource shutdownCompletion,
    CancellationToken cancellationToken)
  {
    var messageChannel = GetMessageChannel(receiving.Sender);

    if (!receivingCompletion.Task.IsCompleted)
    {
      receivingCompletion.SetResult();
    }

    await foreach (var message in messageChannel.Reader.ReadAllAsync(cancellationToken).ConfigureAwait(false))
    {
      if (CheckShutdown(shutdownCompletion, cancellationToken))
      {
        break;
      }

      await receiving.FuncToHandleMessage.Invoke(receiving.Sender, message, cancellationToken).ConfigureAwait(false);

      if (CheckShutdown(shutdownCompletion, cancellationToken))
      {
        break;
      }
    }
  }

  private ValueTask Send(MessageSending sending, CancellationToken cancellationToken)
  {
    var messageChannel = GetMessageChannel(sending.Receiver);

    return messageChannel.Writer.WriteAsync(sending.Message, cancellationToken);
  }
}

