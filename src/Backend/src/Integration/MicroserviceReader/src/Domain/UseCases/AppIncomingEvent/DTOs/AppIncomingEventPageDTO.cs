namespace Makc.Dummy.Integration.MicroserviceReader.Domain.UseCases.AppIncomingEvent.DTOs;

/// <summary>
/// Объект передачи данных страницы входящих событий приложения.
/// </summary>
/// <param name="Items">Элементы.</param>
/// <param name="TotalCount">Общее количество.</param>
public record AppIncomingEventPageDTO(
  List<AppIncomingEventSingleDTO> Items,
  long TotalCount) : PageDTO<AppIncomingEventSingleDTO, long>(Items, TotalCount);
