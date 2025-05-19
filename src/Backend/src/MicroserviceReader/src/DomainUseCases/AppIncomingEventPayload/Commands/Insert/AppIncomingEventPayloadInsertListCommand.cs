namespace Makc.Dummy.MicroserviceReader.DomainUseCases.AppIncomingEventPayload.Commands.Insert;

/// <summary>
/// Команда вставки списка полезных нагрузок входящего события приложения.
/// </summary>
/// <param name="Items">Элементы.</param>
public record AppIncomingEventPayloadInsertListCommand(List<AppIncomingEventPayloadCommandDataSection> Items);
