namespace Makc.Dummy.Shared.Core.Message.Funcs;

/// <summary>
/// Функция обработки сообщения.
/// </summary>
/// <param name="sender">Отправитель.</param>
/// <param name="message">Сообщение.</param>
/// <param name="cancellationToken">Токен отмены.</param>
/// <returns>Задача.</returns>
public delegate Task MessageFuncToHandle(string sender, string message, CancellationToken cancellationToken);
