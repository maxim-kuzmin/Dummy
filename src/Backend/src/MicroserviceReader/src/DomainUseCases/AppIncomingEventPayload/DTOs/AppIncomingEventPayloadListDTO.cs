namespace Makc.Dummy.MicroserviceReader.DomainUseCases.AppIncomingEventPayload.DTOs;

/// <summary>
/// Объект передачи данных списка полезных нагрузок входящего события приложения.
/// </summary>
/// <param name="Items">Элементы.</param>
/// <param name="TotalCount">Общее количество.</param>
public record AppIncomingEventPayloadListDTO(
  List<AppIncomingEventPayloadSingleDTO> Items,
  long TotalCount) : ListDTO<AppIncomingEventPayloadSingleDTO, long>(Items, TotalCount);
