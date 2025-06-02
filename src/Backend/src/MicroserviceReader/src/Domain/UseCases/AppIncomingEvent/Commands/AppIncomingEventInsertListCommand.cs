namespace Makc.Dummy.MicroserviceReader.Domain.UseCases.AppIncomingEvent.Commands;

/// <summary>
/// Команда вставки списка входящих событий приложения.
/// </summary>
/// <param name="Items">Элементы.</param>
public record AppIncomingEventInsertListCommand(List<AppIncomingEventCommandDataSection> Items);
