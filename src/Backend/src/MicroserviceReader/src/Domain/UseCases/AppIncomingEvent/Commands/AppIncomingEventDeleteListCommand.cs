namespace Makc.Dummy.MicroserviceReader.Domain.UseCases.AppIncomingEvent.Commands;

/// <summary>
/// Команда удаления списка входящих событий приложения.
/// </summary>
/// <param name="ObjectIds">Идентификаторы объектов.</param>
public record AppIncomingEventDeleteListCommand(List<string>? ObjectIds);
