namespace Makc.Dummy.Reader.DomainUseCases.AppIncomingEvent.DTOs;

/// <summary>
/// Объект передачи данных одиночного входящего события приложения.
/// </summary>
/// <param name="Id">Идентификатор.</param>
/// <param name="CreatedAt">Когда создано.</param>
/// <param name="IsPublished">Опубликовано ли?</param>
/// <param name="Name">Имя.</param>
public record AppIncomingEventSingleDTO(long Id, DateTimeOffset CreatedAt, bool IsPublished, string Name);
