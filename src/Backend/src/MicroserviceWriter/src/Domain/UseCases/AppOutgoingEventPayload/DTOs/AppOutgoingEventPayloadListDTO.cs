namespace Makc.Dummy.MicroserviceWriter.Domain.UseCases.AppOutgoingEventPayload.DTOs;

/// <summary>
/// Объект передачи данных списка полезных нагрузок исходящего события приложения.
/// </summary>
/// <param name="Items">Элементы.</param>
/// <param name="TotalCount">Общее количество.</param>
public record AppOutgoingEventPayloadListDTO(
  List<AppOutgoingEventPayloadSingleDTO> Items,
  long TotalCount) : ListDTO<AppOutgoingEventPayloadSingleDTO, long>(Items, TotalCount);
