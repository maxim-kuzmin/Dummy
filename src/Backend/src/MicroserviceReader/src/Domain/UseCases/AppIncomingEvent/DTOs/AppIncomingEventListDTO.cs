namespace Makc.Dummy.MicroserviceReader.Domain.UseCases.AppIncomingEvent.DTOs;

/// <summary>
/// Объект передачи данных списка входящих событий приложения.
/// </summary>
/// <param name="Items">Элементы.</param>
/// <param name="TotalCount">Общее количество.</param>
public record AppIncomingEventListDTO(
  List<AppIncomingEventSingleDTO> Items,
  long TotalCount) : ListDTO<AppIncomingEventSingleDTO, long>(Items, TotalCount);
