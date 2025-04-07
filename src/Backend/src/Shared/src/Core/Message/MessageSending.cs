namespace Makc.Dummy.Shared.Core.Message;

/// <summary>
/// Отправка сообщений.
/// </summary>
/// <param name="Receiver">Получатель.</param>
/// <param name="Message">Сообщение.</param>
public record MessageSending(string Receiver, string Message);
