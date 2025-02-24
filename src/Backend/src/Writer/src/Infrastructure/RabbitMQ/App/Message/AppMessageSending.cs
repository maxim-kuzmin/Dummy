namespace Makc.Dummy.Writer.Infrastructure.RabbitMQ.App.Message;

/// <summary>
/// Отправка сообщений приложения.
/// </summary>
/// <param name="Receiver">Получатель.</param>
/// <param name="Message">Сообщение.</param>
public record AppMessageSending(string Receiver, string Message)
{  
  private readonly TaskCompletionSource _tcs = new();
  
  /// <summary>
  /// Задача для завершения.
  /// </summary>
  public Task TaskToComplete => _tcs.Task;

  /// <summary>
  /// Отменить.
  /// </summary>
  /// <param name="cancellationToken">Токен отмены.</param>
  public void Cancel(CancellationToken cancellationToken)
  {
    _tcs.SetCanceled(cancellationToken);
  }

  /// <summary>
  /// Завершить.
  /// </summary>
  public void Complete()
  {
    _tcs.SetResult();
  }
}
