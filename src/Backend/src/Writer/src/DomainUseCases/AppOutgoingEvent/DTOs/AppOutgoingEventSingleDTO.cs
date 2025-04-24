namespace Makc.Dummy.Writer.DomainUseCases.AppOutgoingEvent.DTOs;

/// <summary>
/// Объект передачи данных одиночного исходящего события приложения.
/// </summary>
/// <param name="Id">Идентификатор.</param>
/// <param name="CreatedAt">Когда создано.</param>
/// <param name="IsPublished">Опубликовано ли?</param>
/// <param name="Name">Имя.</param>
public record AppOutgoingEventSingleDTO(long Id, DateTimeOffset CreatedAt, bool IsPublished, string Name);
