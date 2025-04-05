namespace Makc.Dummy.Shared.Core.Message.Buses;

/// <summary>
/// Шина сообщений, хранящихся в памяти.
/// </summary>
public class MemoryMessageBus : MessageBusBase
{
  private readonly Dictionary<string, Channel<string>> _channelLookup = [];

  /// <inheritdoc/>
  public sealed override Task Connect(CancellationToken cancellationToken)
  {
    TaskCompletionSource consumingCompletion = new();

    Task.Run(() => Consume(consumingCompletion, cancellationToken), cancellationToken);

    TaskCompletionSource producingCompletion = new();

    Task.Run(() => Produce(producingCompletion, cancellationToken), cancellationToken);

    return Task.WhenAll(consumingCompletion.Task, producingCompletion.Task);
  }

  private async Task Consume(TaskCompletionSource consumingCompletion, CancellationToken cancellationToken)
  {
    if (!consumingCompletion.Task.IsCompleted)
    {
      consumingCompletion.SetResult();
    }

    await foreach (var receiving in Receivings.Reader.ReadAllAsync(cancellationToken).ConfigureAwait(false))
    {
      var channel = GetChannel(receiving.Sender);

      var subscribingTask = Subscribe(channel, receiving, cancellationToken);

      await subscribingTask.ConfigureAwait(false);
    }
  }

  private Channel<string> GetChannel(string key)
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

  private async Task Produce(TaskCompletionSource producingCompletion, CancellationToken cancellationToken)
  {
    if (!producingCompletion.Task.IsCompleted)
    {
      producingCompletion.SetResult();
    }

    await foreach (var sending in Sendings.Reader.ReadAllAsync(cancellationToken).ConfigureAwait(false))
    {
      var channel = GetChannel(sending.Receiver);

      var publishingTask = channel.Writer.WriteAsync(sending.Message, cancellationToken);

      await publishingTask.ConfigureAwait(false);

      sending.Complete();
    }
  }

  private static Task Subscribe(
    Channel<string> channel,
    MessageReceiving receiving,
    CancellationToken cancellationToken)
  {
    TaskCompletionSource completion = new();

    Task.Run(() => Subscribe(completion, channel, receiving, cancellationToken), cancellationToken);

    return completion.Task;
  }

  private static async Task Subscribe(
    TaskCompletionSource completion,
    Channel<string> channel,
    MessageReceiving receiving,
    CancellationToken cancellationToken)
  {
    if (!completion.Task.IsCompleted)
    {
      completion.SetResult();
    }

    await foreach (var message in channel.Reader.ReadAllAsync(cancellationToken).ConfigureAwait(false))
    {
      await receiving.FuncToHandleMessage.Invoke(receiving.Sender, message, cancellationToken).ConfigureAwait(false);
    }
  }
}

