namespace Makc.Dummy.MicroserviceWriter.DomainUseCases.AppOutgoingEvent.DTOs;

/// <summary>
/// Объект передачи данных списка исходящих событий приложения.
/// </summary>
/// <param name="Items">Элементы.</param>
/// <param name="TotalCount">Общее количество.</param>
public record AppOutgoingEventListDTO(
  List<AppOutgoingEventSingleDTO> Items,
  long TotalCount) : ListDTO<AppOutgoingEventSingleDTO, long>(Items, TotalCount);
