namespace Makc.Dummy.Shared.Core.Message;

/// <summary>
/// Получение сообщения.
/// </summary>
/// <param name="Sender">Отправитель.</param>
/// <param name="FuncToHandleMessage">Функция обработки сообщения.</param>
public record MessageReceiving(string Sender, MessageFuncToHandle FuncToHandleMessage);
