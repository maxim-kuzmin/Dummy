﻿namespace Makc.Dummy.Shared.Core.Message;

/// <summary>
/// Отправка сообщений.
/// </summary>
/// <param name="Receiver">Получатель.</param>
/// <param name="Message">Сообщение.</param>
public record MessageSending(string Receiver, string Message)
{  
  private readonly TaskCompletionSource _completion = new();
  
  /// <summary>
  /// Задача завершения.
  /// </summary>
  public Task CompletionTask => _completion.Task;

  /// <summary>
  /// Отменить.
  /// </summary>
  /// <param name="cancellationToken">Токен отмены.</param>
  public void Cancel(CancellationToken cancellationToken)
  {
    if (!_completion.Task.IsCanceled)
    {
      _completion.SetCanceled(cancellationToken);
    }
  }

  /// <summary>
  /// Завершить.
  /// </summary>
  public void Complete()
  {
    if (!_completion.Task.IsCompleted)
    {
      _completion.SetResult();
    }
  }
}
