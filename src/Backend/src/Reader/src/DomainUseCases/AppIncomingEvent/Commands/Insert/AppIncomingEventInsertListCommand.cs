namespace Makc.Dummy.Reader.DomainUseCases.AppIncomingEvent.Commands.Insert;

/// <summary>
/// Команда вставки списка входящих событий приложения.
/// </summary>
/// <param name="Items">Элементы.</param>
public record AppIncomingEventInsertListCommand(List<AppIncomingEventInsertSingleCommand> Items);
