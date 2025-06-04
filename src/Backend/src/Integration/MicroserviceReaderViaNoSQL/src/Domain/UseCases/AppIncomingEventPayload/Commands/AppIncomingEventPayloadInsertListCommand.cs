namespace Makc.Dummy.Integration.MicroserviceReaderViaNoSQL.Domain.UseCases.AppIncomingEventPayload.Commands;

/// <summary>
/// Команда вставки списка полезных нагрузок входящего события приложения.
/// </summary>
/// <param name="Items">Элементы.</param>
public record AppIncomingEventPayloadInsertListCommand(List<AppIncomingEventPayloadCommandDataSection> Items);
