namespace Makc.Dummy.Integration.MicroserviceWriter.Domain.UseCases.AppOutgoingEvent.DTOs;

/// <summary>
/// Объект передачи данных страницы исходящих событий приложения.
/// </summary>
/// <param name="Items">Элементы.</param>
/// <param name="TotalCount">Общее количество.</param>
public record AppOutgoingEventPageDTO(
  List<AppOutgoingEventSingleDTO> Items,
  long TotalCount) : PageDTO<AppOutgoingEventSingleDTO, long>(Items, TotalCount);
