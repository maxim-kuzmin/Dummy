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
    if (!Init(AppConfigOptionsMessageDirectionEnum.Both))
    {
      return Task.CompletedTask;
    }

    TaskCompletionSource consumingCompletion = new();

    if (Receivings != null)
    {
      Task.Run(() => Consume(Receivings, consumingCompletion, cancellationToken), cancellationToken);
    }
    else
    {
      consumingCompletion.SetResult();
    }

    TaskCompletionSource producingCompletion = new();

    if (Sendings != null)
    {
      Task.Run(() => Produce(Sendings, producingCompletion, cancellationToken), cancellationToken);
    }
    else
    {
      producingCompletion.SetResult();
    }

    return Task.WhenAll(consumingCompletion.Task, producingCompletion.Task);
  }

  private async Task Consume(
    Channel<MessageReceiving> receivings,
    TaskCompletionSource consumingCompletion,
    CancellationToken cancellationToken)
  {
    if (!consumingCompletion.Task.IsCompleted)
    {
      consumingCompletion.SetResult();
    }

    await foreach (var receiving in receivings.Reader.ReadAllAsync(cancellationToken).ConfigureAwait(false))
    {
      await Receive(receiving, cancellationToken).ConfigureAwait(false);
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

  private async Task Produce(
    Channel<MessageSending> sendings,
    TaskCompletionSource producingCompletion,
    CancellationToken cancellationToken)
  {
    if (!producingCompletion.Task.IsCompleted)
    {
      producingCompletion.SetResult();
    }

    await foreach (var sending in sendings.Reader.ReadAllAsync(cancellationToken).ConfigureAwait(false))
    {
      await Send(sending, cancellationToken).ConfigureAwait(false);

      sending.Complete();
    }
  }

  private Task Receive(MessageReceiving receiving, CancellationToken cancellationToken)
  {
    TaskCompletionSource receivingCompletion = new();    

    Task.Run(() => Receive(receiving, receivingCompletion, cancellationToken), cancellationToken);

    return receivingCompletion.Task;
  }

  private async Task Receive(    
    MessageReceiving receiving,
    TaskCompletionSource receivingCompletion,
    CancellationToken cancellationToken)
  {
    var channel = GetChannel(receiving.Sender);

    if (!receivingCompletion.Task.IsCompleted)
    {
      receivingCompletion.SetResult();
    }

    await foreach (var message in channel.Reader.ReadAllAsync(cancellationToken).ConfigureAwait(false))
    {
      await receiving.FuncToHandleMessage.Invoke(receiving.Sender, message, cancellationToken).ConfigureAwait(false);
    }
  }

  private ValueTask Send(MessageSending sending, CancellationToken cancellationToken)
  {
    var channel = GetChannel(sending.Receiver);

    return channel.Writer.WriteAsync(sending.Message, cancellationToken);
  }
}

